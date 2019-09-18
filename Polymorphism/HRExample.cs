using System;
namespace Polymorphism.HumanResource
{
    public abstract class BaseEmployee
    {
        public int EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get { return this.FirstName + " " + this.LastName;  } }

        public decimal Salary { get; set; } = 599999;
        public virtual decimal GetSalary()
        {
            return this.Salary;
        }

        public virtual void Print()
        {
            System.Console.WriteLine("ID : {0}", this.EmployeeID);
            System.Console.WriteLine("First Name : {0}", this.FirstName);
            System.Console.WriteLine("Last Name : {0}", this.LastName);
            System.Console.WriteLine("Full Name : {0}", this.FullName);
            System.Console.WriteLine("Salary : {0}", this.GetSalary());
        }
    }
    public class FacultyEmployee : BaseEmployee
    {
      
    }
    public class AdminEmployee : BaseEmployee
    {
      
    }
    public class ContractEmployee : BaseEmployee
    {      
        public int Hours { get; set; }
        public decimal Rate { get; set; }

        public override decimal GetSalary()
        {
            this.Salary = Hours* Rate;
            return this.Salary;
        }
    }

    public class PolymorphismDemo
    {
        static void Main_HRDemo(string[] args)
        {
            BaseEmployee be = new AdminEmployee();
            be.Print();

            be = new FacultyEmployee()
            {
                EmployeeID = 1,
                FirstName = "Abdul",
                LastName = "Makid"
            };
            be.Print();

            be = new ContractEmployee()
            {
                Hours = 300,
                Rate = 18
            };

            be.Print();
            Console.ReadKey();
        }
    }
}
