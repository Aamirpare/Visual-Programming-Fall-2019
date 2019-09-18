using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polymorphism.Delegates
{
    class Program
    {
        // declare delegate
        public delegate void Print(int value);



        static void Main199(string[] args)
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

        public static void Main_the_Old(string[] args)
        {
            Print printDel = PrintNumber;
            printDel += PrintHexadecimal;
            printDel += PrintMoney;

            //printDel(1000);

            printDel -= PrintHexadecimal;
            printDel(2000);

            Console.ReadKey();
        }

        public static void PrintNumber(int num)
        {
            Console.WriteLine("Number: {0,-12:N0}", num);
        }

        public static void PrintMoney(int money)
        {
            Console.WriteLine("Money: {0:C}", money);
        }


        public static void PrintIndex(int index)
        {
            Console.WriteLine("Index : " + index);
        }

        public static void PrintHelper(Print newDelegate, int numToPrint)
        {
            newDelegate(numToPrint);
        }

        public static void PrintHexadecimal(int dec)
        {
            Console.WriteLine("Hexadecimal: {0:X}", dec);
        }
    }
}
