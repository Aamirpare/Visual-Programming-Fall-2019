using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polymorphism.Delegates
{
    public class DelegateDemo
    {
        // declare delegate
        public delegate void Print(int value);

        //Example 1 - Using Delegates 
        public void DelegateImplementation()
        {
            // Print delegate points to PrintNumber
            Print printDel = PrintNumber;
            // or
            // Print printDel = new Print(PrintNumber);

            printDel(100000);
            printDel(200);
            printDel(333);

            // Print delegate points to PrintMoney
            printDel = PrintMoney;

            printDel(10000);
            printDel(200);

            Print newDel = PrintIndex;

            newDel(100);
            newDel(101);
            newDel(102);

            PrintHelper(newDel, 9000);
            PrintHelper(printDel, 290);


            Console.ReadKey();
        }

        //Example 2 - Passing Delegates as parameters
        public void DelegatesAsParameters()
        {
            // Print delegate points to PrintNumber
            Print printDel = PrintNumber;
            // or
            // Print printDel = new Print(PrintNumber);

            Print newDel = PrintIndex;

            PrintHelper(newDel, 9000);
            PrintHelper(printDel, 290);


            Console.ReadKey();
        }
        //Example 3 - Delegate Multicasting
        public  void DelegateMulticasting()
        {
            Print printDel = PrintNumber;
            printDel += PrintHexadecimal;
            printDel += PrintMoney;

            //printDel(1000);

            printDel -= PrintHexadecimal;
            printDel(2000);

            Console.ReadKey();
        }


        //Methods called using delegate reference
        public void PrintNumber(int num)
        {
            Console.WriteLine("Number: {0,-12:N0}", num);
        }

        public void PrintMoney(int money)
        {
            Console.WriteLine("Money: {0:C}", money);
        }

        public void PrintIndex(int index)
        {
            Console.WriteLine("Index : " + index);
        }
        public void PrintHelper(Print newDelegate, int numToPrint)
        {
            newDelegate(numToPrint);
        }
        public void PrintHexadecimal(int dec)
        {
            Console.WriteLine("Hexadecimal: {0:X}", dec);
        }
        public static void Main_delegate(string[] args)
        {
            DelegateDemo demo = new DelegateDemo();
            //demo.DelegateImplementation();
            //demo.DelegatesAsParameters();
            demo.DelegateMulticasting();
            Console.ReadKey();
        }

    }
}
