using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polymorphism
{

    interface IEmployee
    {
        void Upload();
    }
    public abstract class BaseEmployee
    {
        protected int EmployeeID { get; set; }
        protected string FullName { get; set; }
        public virtual void Print()
        {
            Console.WriteLine("Employee Information");
            Console.WriteLine("Employee ID : " + this.EmployeeID);
            Console.WriteLine("FullName : " + this.FullName);
            Console.WriteLine("Salary : " + this.Salary);

        }

        public BaseEmployee(int id, string fname)
        {
            this.EmployeeID = id;
            this.FullName = fname;
        }
        public decimal Salary { get; set; }
        public abstract decimal CalculateSalary();
    }

    public class Faculty : BaseEmployee, IEmployee
    {
        public void Upload()
        {
            Console.WriteLine("Documents Uploaded.");
        }
        public Faculty(int id, string fname):base(id, fname)
        {
            //this.EmployeeID = id;
            //this.FullName = fname;
            this.Salary = 30000;
        }


        public override decimal CalculateSalary()
        {
            return this.Salary;
        }

        
    }

    public class Staff : BaseEmployee, IEmployee
    {
        public int Hours { get; set; }
        public decimal Rate { get; set; }
        //public override void Print()
        //{
        //    //base.Print();
        //    Console.WriteLine("The staff header");
        //}

        public void Upload()
        {
            Console.WriteLine("Staff employee documents are uploaded.");
        }

        public Staff(int id, string fname): base(id, fname)
        {
            //this.EmployeeID = id;
            //this.FullName = fname;
            this.Hours = 40;
            this.Rate = 1000;
            this.CalculateSalary();
        }

        public override decimal CalculateSalary()
        {
            this.Salary = Hours * Rate;
            return this.Salary;
        }
    }

    public class AdminEmployee : BaseEmployee
    {
        public AdminEmployee(int id, string fname):base(id, fname)
        {
            this.Salary = 60000;
        }

        public override decimal CalculateSalary()
        {
            return this.Salary;
        }

    }
}
