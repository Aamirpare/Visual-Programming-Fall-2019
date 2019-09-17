using Polymorphism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HR = Polymorphism.HumanResource;

namespace Polymorphism
{
    class Program
    {
        static void Main(string[] args)
        {
            HR::BaseEmployee be = new HR::AdminEmployee();
            be.Print();

            be = new HR::FacultyEmployee()
            {
                EmployeeID = 1,
                FirstName = "Abdul",
                LastName = "Makid"
            };
            be.Print();

            be = new HR::ContractEmployee()
            {
                Hours = 300,
                Rate = 18
            };

            be.Print();
            Console.ReadKey();
        }
        static void Main2(string [] args)
        {
            SimpleMessageService sm = new SimpleMessageService();
            Console.WriteLine("");
            EmailService es = new EmailService();
            Console.ReadKey();
        }
        static void Main1(string[] args)
        {
            BaseEmployee employee = new Faculty(100, "Aamir");
            
            employee.Print();

            employee = new Staff(200, "Mohiuddin");
            
            employee.Print();

            employee = new AdminEmployee(800, "Amjad Khan");
            employee.Print();

            Console.ReadKey();
        }

    }
}
