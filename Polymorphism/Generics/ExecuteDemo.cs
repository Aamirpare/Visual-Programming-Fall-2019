using System;

namespace Polymorphism.Generics
{
    public class ExecuteDemo : GenericArray<string>
    {
        public static void Main_generics(string[] args)
        {
            GenericArray<string> gArray = new GenericArray<string>(5);
            gArray.SetItem("aamir", 0);
            gArray.SetItem("kabir", 1);
            gArray.SetItem("adeel", 2);
            gArray.Display();

            GenericArray<int> iArray = new GenericArray<int>(4);
            iArray.SetItem(90,0);
            iArray.SetItem(30,1);
            iArray.SetItem(20,2);
            iArray.SetItem(20,21);
            iArray.Display();

            GenericArray<float> fArray = new GenericArray<float>(4);
            fArray.SetItem(90.4f, 0);
            fArray.SetItem(30.6f, 1);
            fArray.SetItem(20, 2);
            fArray.Display();

            Console.ReadKey();
        }
    }

}
