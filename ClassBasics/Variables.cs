
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.Pricipal.HR;

namespace ClassBasics
{
    //1 Declaring Variables
       //Local Variables
       //Class Variables
    class Variables
    {
        public void ImplicitType()
        {
            var x = 100;
            var y = "First Surgery";
            var m = true;
            var p = 100.78;
            var o = new Employee();
            System.Console.WriteLine("X = {0}", x);
            System.Console.WriteLine("Y = {0}", y);
            System.Console.WriteLine("M = {0}", m);
            System.Console.WriteLine("P = {0}", p);
            o.DisplayEmployee();
        }
        public void Switch(int choice)
        {
            var option = 100;
            switch (option)
            {
                case 100:
                    System.Console.WriteLine("Your case is matched");
                    break; 
                default:
                    break;
            }
            switch (choice)
            {
                case 100:
                    System.Console.WriteLine("Choice is 1");
                    break;
                case 200:
                    System.Console.WriteLine("Choice is 2");
                    break;
                case 300:
                    System.Console.WriteLine("Choice is 3");
                    break;

                default:
                    System.Console.WriteLine("Default Choice");
                    break;
            }
        }
        public void DemoVaraibles()
        {
            //System.Int32 index = 100, age, position, id= 2;
            //long i = 0;
            //System.Int64 _234i = 0;
            //string name = "Anonnymous dsafjh;lsadjfsadl";

            int index = 0;
            float price = 8;
            index = (int)price;
            float money = 10.33f;
            double m2 = 10.33d;
            money = (float)m2;
            sbyte itemCount = 51;

            if (itemCount > 50)
            {
                System.Console.WriteLine("You have enough to spend");

            }
            else if (itemCount > 50)
            {
                System.Console.WriteLine("You are able to play a game");

            }
            else
            {
                System.Console.WriteLine("You are short of enough to spend");

            }

            System.Console.WriteLine("Money : " + money);
            System.Console.WriteLine("Item Count : " + itemCount);
            //string result = $"money : {money},\nItem Count : {itemCount}";
            //System.Console.WriteLine(result);
        }
    }
}
