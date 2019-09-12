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
    }
}
