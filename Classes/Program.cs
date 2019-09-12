using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T = Teaching;
namespace Classes
{
    class Program
    {
        static void Main(string[] args)
        {
            Variables x = new Variables();
            x.ImplicitType();
            Console.ReadKey();
        }
        static void Mainc(string[] args)
        {


            T.Registration r2 = new T.Registration();
            Registration r1 = new Registration();
            r1.RollNo = "FA12-BSSE-890";
            r1.FullName = "Unknown Student";
            if (!r1.IsStudentActive())
            {
                r1.ShowRegistration();
            }

            var x = r1.Clone();
            x.ShowRegistration();
            Console.ReadKey();
        }

    }
}
