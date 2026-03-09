namespace DemoWebApiDB.Infrastructure.Results;


/// <summary>
///     Represents the outcome status of a service operation.
///     This is later translated to an appropriate HTTP response in the API layer.
/// </summary>
public enum ResultStatus
{

    /// <summary>
    ///     Operation completed successfully.
    ///     For 200 "OK" responses when data is returned, or 204 "No Content" when no data is returned.
    /// </summary>
    Success,

    /// <summary>
    ///     Resource successfully created.
    ///     For 201 "Created" responses.
    /// </summary>
    Created,


    /// <summary>
    ///     Operation accepted (typically for PUT updates).
    ///     For 202 "Accepted" responses.
    /// </summary>
    Accepted,


    /// <summary>
    ///     Requested resource was not found.  
    ///     For 404 "Not Found" responses.
    /// </summary>
    NotFound,


    /// <summary>
    ///     Validation errors occurred.
    ///     For 400 "Bad Request" responses when input validation fails.
    /// </summary>
    ValidationError,


    /// <summary>
    ///     Data Concurrency issue (version mismatch during update/delete).
    ///     For 412 "Precondition Failed" responses when using concurrency controls.
    /// </summary>
    Concurrency,


    /// <summary>
    ///     Conflict occurred (e.g., duplicate found).
    ///     For 409 "Conflict" responses when a conflict with the current state occurs.
    /// </summary>
    Conflict,


    /// <summary>
    ///     Unauthorized access.
    ///     For 401 "Unauthorized" responses when authentication is required but missing or invalid.
    /// </summary>
    Unauthorized,


    /// <summary>
    ///     Authenticated but forbidden.
    ///     For 403 "Forbidden" responses when the user does not have permission, despite being authenticated.
    /// </summary>
    Forbidden,


    /// <summary>
    ///     Unexpected system error.
    ///     For 500 "Internal Server Error" responses, when an unhandled exception or critical failure occurs.
    /// </summary>
    Error

}
