using System;
using System.Collections.Generic;
using System.Text;

namespace Demo_IComparable
{
    public class Employee
        : System.IComparable
    {
        
        public enum SortOnFields
        {
            Name,
            Id
        };
        public enum SortOrders
        {
            Ascending,
            Descending
        }

        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Salary { get; set; }

        public static SortOnFields SortOn { get; set; } = SortOnFields.Id;
        public static SortOrders SortOrder { get; set; } = SortOrders.Ascending;


        #region System.IComparable members

        public int CompareTo(object? obj)
        {
            Employee? objOther = obj as Employee;
            if (objOther is not null)
            {
                switch (Employee.SortOn)
                {
                    default:
                    case SortOnFields.Id:
                        return (SortOrder == SortOrders.Ascending) 
                            ? this.Id.CompareTo(objOther.Id)       // ascending order on ID
                            : objOther.Id.CompareTo(this.Id);       // descending order on ID
                    case SortOnFields.Name:
                        if (SortOrder == SortOrders.Ascending)
                            return this.Name.CompareTo(objOther.Name);
                        else
                            return objOther.Name.CompareTo(this.Name);
                }
            }

            return 0;
        }

        #endregion
    }
}
