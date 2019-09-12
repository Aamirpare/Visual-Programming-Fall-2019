using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polymorphism
{
    class Program
    {
        static void Main(string[] args)
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
