using Microsoft.AspNetCore.Http;
using Serilog.Context;


namespace DemoWebApiDB.Infrastructure.Middleware;

/**********************************************************

    Now, the API returns a structured error response with a correlation

        {
          "title": "Conflict",
          "status": 409,
          "detail": "Another category with name 'abs' already exists.",
          "instance": "/api/categories/1002",
          "errorCode": "CATEGORY_DUPLICATE",
          "correlationId": "6f8c5a1e7f0d4a3db1f8a9c0d5b4e2a1"
        }

    Response header:

        X-Correlation-ID: 6f8c5a1e7f0d4a3db1f8a9c0d5b4e2a1

 ***********************************/



/// <summary>
///     Middleware responsible for managing the CorrelationId for each HTTP request.
///
///     Responsibilities:
///     - Accept an incoming CorrelationId header if provided by the client
///     - Generate a new CorrelationId if none exists
///     - Store the CorrelationId in HttpContext.Items for downstream access
///     - Push the CorrelationId into Serilog logging context
///     - Return the CorrelationId in the HTTP response header
/// </summary>
/// <remarks>
///     This enables:
///     - End-to-end request tracing
///     - Easier log diagnostics
///     - Client-side troubleshooting using the returned CorrelationId
///     
///     The flow of the middleware would be:
///             Client Request
///                   |
///             CorrelationIdMiddleware
///                   │
///             Push CorrelationId into Serilog
///                   │
///             _next(context)
///                   │
///             Authentication Middleware
///                   │
///             Routing Middleware
///                   │
///             Controller
/// </remarks>
public sealed class CorrelationIdMiddleware
{

    /// <summary>
    /// Header name used to transmit the correlation identifier.
    /// </summary>
    private const string CorrelationHeaderName = "X-Correlation-ID";


    /// <summary>
    /// HttpContext key used to store correlation id.
    /// </summary>
    public const string CorrelationItemKey = "CorrelationId";


    private readonly RequestDelegate _next;


    /// <summary>
    ///     Initializes a new instance of <see cref="CorrelationIdMiddleware"/>.
    /// </summary>
    /// <param name="next">The next middleware in the pipeline.</param>
    public CorrelationIdMiddleware(RequestDelegate next)
    {
        _next = next;
    }


    /// <summary>
    ///     Processes the incoming HTTP request and attaches the correlation identifier.
    /// </summary>
    /// <param name="context">Current HTTP context.</param>
    public async Task InvokeAsync(HttpContext context)
    {
        // Attempt to read the CorrelationId from incoming request header.
        // This allows distributed systems to propagate the same correlation ID.
        string? correlationId = context.Request.Headers[CorrelationHeaderName].FirstOrDefault();

        // If not provided by the caller, generate a new one.
        if (string.IsNullOrWhiteSpace(correlationId))
        {
            correlationId = Guid.NewGuid().ToString("N");
        }

        // Store in HttpContext for later use (e.g., ProblemDetails builder).
        context.Items[CorrelationItemKey] = correlationId;

        // Push correlationId into Serilog logging scope
        using (LogContext.PushProperty(CorrelationItemKey, correlationId))
        {
            // Ensure response header contains correlation id
            context.Response.OnStarting(() =>
            {
                if (!context.Response.Headers.ContainsKey(CorrelationHeaderName))
                {
                    context.Response.Headers.Add(CorrelationHeaderName, correlationId);
                }

                return Task.CompletedTask;
            });

            await _next(context);
        }

    }

}