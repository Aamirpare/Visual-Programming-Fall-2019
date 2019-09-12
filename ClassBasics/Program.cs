using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using University.Pricipal.HR;

using U = University.Pricipal.HR;

namespace ClassBasics
{
    class Program
    {
        static void Main(string[] args)
        {
            //Variables x = new Variables();
            //x.DemoVaraibles();
            //x.Switch(300);
            //x.ImplicitType();

           
            Console.ReadKey();
        }
        static void Main1(string[] args)
        {
            //University.Pricipal.HR.Employee emp1 = new University.Pricipal.HR.Employee();
            //U.Employee emp1 = new U.Employee();    
            U::Employee emp1 = new U::Employee();    
            Console.ReadKey();
        }
    }
}
