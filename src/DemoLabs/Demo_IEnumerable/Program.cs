using System.Collections;

namespace Demo_IEnumerable
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Demo01();

            // Collection Initialization
            int[] arr = { 10, 20, 30, 50 };     

            // Object Initialization
            Employee obj = new Employee() { Id = 1, Name = "First Employee", Salary = 2000M };


            // Collection Initialization using Object initialization for each employee object
            // NOTE: 
            //      (a) should implement IEnumerable interface
            //      (b) should have "public void Add( <arg> )" with single argument
            Company objCompany 
                = new Company("Microsoft")
                {
                    new Employee() { Id = 101, Name = "First Employee", Salary = 1000M },
                    new Employee() { Id = 102, Name = "Second Employee", Salary = 170.85M },
                    new Employee() { Id = 103, Name = "Third Employee", Salary = 2050.50M }
                };

        }



        private static void Demo01()
        {
            Company objCompany = new Company("Microsoft");

            Employee empFirst 
                = new Employee() { Id = 101, Name = "First Employee", Salary = 1000M };
            Employee empSecond 
                = new Employee() { Id = 102, Name = "Second Employee", Salary = 170.85M };
            Employee empThird 
                = new Employee() { Id = 103, Name = "Third Employee", Salary = 2050.50M };

            objCompany.Add(empFirst);
            objCompany.Add(empSecond);
            objCompany.Add(empThird);

            objCompany.DisplayInfo();
            Console.WriteLine();

            foreach (Employee emp in objCompany)     // implicitly calls the GetEnumerator() method
            {
                // emp = new Employee();            // READ-ONLY FORWARD-ONLY

                Console.WriteLine("{0,2} {1,-30} {2,15:C}", emp.Id, emp.Name, emp.Salary);
            }

            Console.WriteLine();

            // ONLY FOR REFERENCE
            // IEnumerator obj = objCompany.GetEnumerator();
            // obj.Reset();
            // while(obj.MoveNext())
            // {
            //    Employee? emp = obj.Current as Employee;
            //    if( emp is not null)
            //    {
            //        Console.WriteLine("{0,2} {1,-30} {2,15:C}", emp.Id, emp.Name, emp.Salary);
            //    }
            // }
        }
    }
}
