namespace Demo_Extensions
{
    /// <summary>
    ///     Demo of Extension Methods
    ///     NOTE:
    ///         First Preference is given to the class if the method is implemented by it.
    ///         If no method found, then Extension Method would be invoked.
    /// </summary>
    internal class Program
    {
        static void Main(string[] args)
        {
            TypeInferenceDemo();

            Calculator objCalc = new Calculator();
            int x = 50, y = 60;
            Console.WriteLine("Sum of {0} and {1} is {2}", x, y, objCalc.Add(x, y));
            Console.WriteLine();

            // DerivedCalculator objDerivedCalc = new DerivedCalculator();
            // Console.WriteLine("Sum of {0} and {1} is {2}", x, y, objDerivedCalc.Add(x, y));
            // int result = objDerivedCalc(x, y);
            // Console.WriteLine("Product of {0} and {1} is {2}", x, y, result);
            // Console.WriteLine();

            int result;

            Console.WriteLine("-- invoking the Static Method using the Object Extension");
            result = objCalc.Multiply(x, y);
            Console.WriteLine("Product of {0} and {1} is {2}", x, y, result);
            Console.WriteLine();

            Console.WriteLine("-- invoking the Static Method DIRECTLY - which is an ordinary call");
            result = CalculatorExtensions.Multiply(objCalc, x, y);
            Console.WriteLine("Product of {0} and {1} is {2}", x, y, result);
            Console.WriteLine();    
        }

        private static void TypeInferenceDemo()
        {
            int i = 10;
            string s = "hello world";

            object o = i;
            // o++;

            // Type Inference (Type is identified on initialization)
            var x = 20;
            x++;

            var y = o;

            var intArr = new int[5] { 1, 2, 3, 4, 5 };
            var objArr = new object[5];

            System.Collections.ArrayList alList = new System.Collections.ArrayList();
            var alist = new System.Collections.ArrayList();

            System.Collections.ArrayList alist2 = new();        // C# 12.0 feature
        }
    }
}
