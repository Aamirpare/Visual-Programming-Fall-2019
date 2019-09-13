using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class Variables
    {
        public string MyMethod()
        {
            var result = "Functional Programing";
            return result;
        }
        public void ImplicitType()
        {
            var index = 90;
            var name = "Marry";
            var isSucceed = true;

            Console.WriteLine($"index : {index}, Name : {name}, Success : {isSucceed}");

            var emp = new Teaching.Registration();
            emp.Display();
        }
        public void Demo()
        {
            //int index = 90, age = 23, itemIndex = "sadfj";
            //int index = 90;
            System.Int32 index = 90;
            //bool isTrue = false;
            Boolean isTrue = false;

            int i = 10;

            float f = i;
            i = (int)f; 

            int age = 34;
            int itmeNo = 23;

            byte invoice = 255;

            string fullName = "Anonymous";
            bool isActive;
            //age = true;
            isActive = true;

            float price = 900.99f;
            double balance = 900.99;

            //price = balance;
           
        }
        public void AutomaticAssignment()
        {
            //char to ushort, uint, ulong, float, double, decimal

            Console.WriteLine("char => ushort, uint, ulong, float, double, decimal");
            char s = 'a';
            ushort us = s;
            uint ui = 'a';
            ulong ul = s;
            float f = s;
            double d = s;
            decimal dm = s;
            Console.WriteLine($"{s}, {us}, {ui}, {ul}, {f}, {d}, {dm}");

            sbyte sb = -127;
            Console.WriteLine("Ushort => short, int, long, float, double, decimal");
            short sh = sb;
            int i = sb;
            long l = sb;
            f = sb;
            d = sb;
            dm = sb;
            Console.WriteLine($"{sb}, {sh}, {i}, {l}, {f}, {d}, {dm}");

            byte b = 80;
            Console.WriteLine("byte => short, ushort, int, uint, long, ulong, float, double, decimal");
            sh = b;
            us = b;
            i = b;
            ui = b;
            l = b;
            ul = b;
            f = b;
            d = b;
            dm = b;
            Console.WriteLine($"{sh}, {us}, {i}, {ui}, {l}, {ul}, {f}, {d}, {dm}");

            sh = 845;
            Console.WriteLine("short => int, long, float, double, or decimal");
            i = sh;
            l = sh;
            f = sh;
            d = sh;
            dm = sh;
            Console.WriteLine($"{i}, {l}, {f}, {d}, {dm}");


        }
    }
}
