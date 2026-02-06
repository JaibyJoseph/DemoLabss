using System;
using System.Collections.Generic;
using System.Text;

namespace Demo_Extensions
{
    public sealed class Calculator
    {
        public int Add(int a, int b)
        {
            return a + b; 
        }

        public int Subtract(int a, int b)
        {
            return b - a; 
        }

        public int Multiply(int a, int b)
        {
            Console.WriteLine("--- calling multiply from ORIGINAL CLASS");
            return a * b;
        }


    }

    //public class DerivedCalculator : Calculator
    //{
    //    public int Multiply(int a, int b)
    //    {
    //        return a * b; 
    //    }
    //}


    public static class CalculatorExtensions
    {
        // Inject the "Multiply" method to all objects of the "Calculator" type
        public static int Multiply(this Calculator objCac, int a, int b)
        {
            Console.WriteLine("--- calling multiply from extension method");
            return a * b;
        }

        public static void Author(this object o)
        {
            Console.WriteLine("Author: Trivium");
        }

        public static void DoSomething(this ICloneable obj)
        {

        }
    }
}
