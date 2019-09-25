using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polymorphism.Collections
{
    public class Collections
    {
        public void ArrayListDemo()
        {
            ArrayList al = new ArrayList();
            Console.WriteLine("Array List Demo");

            Console.WriteLine("Adding some numbers:");
            al.Add(2451);
            al.Add(1782);
            al.Add(2331);
            al.Add(1563);
            al.Add(2124);
            al.Add(1235);
            al.Add(191);

            al.Insert(3, 100);

           Console.WriteLine("Capacity: {0} ", al.Capacity);
           Console.WriteLine("Count: {0}", al.Count);

            Console.Write("Content: ");
            foreach (int item in al)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine();
            Console.WriteLine("Sorted Content: ");
            al.Sort();
            foreach (int i in al)
            {
                Console.Write(i + " ");
            }

            Console.WriteLine("Descending order...");
            al.Reverse();
            foreach (int i in al)
            {
                Console.Write(i + " ");
            }


            al.Clear();
            Console.WriteLine($"There is now : {al.Count}");

            Console.WriteLine();
        }
        public void HashTableDemo()
        {
            Hashtable ht = new Hashtable();
            Console.WriteLine("Hashtable Demo");

            ht.Add("100", "Kiren Manika");
            ht.Add("101", "Roshan Asad");
            ht.Add("102", "Anglina Johnson");
            ht.Add("103", "Veronika Alleot");
            ht.Add("104", "Mubashir Kazmi");
            ht.Add("105", "Asad Rabbani Khan");
            ht.Add("106", "Rehimullah Yousuf Zaie");
            ht.Add("007", "Ram Gopal Verma");
            ht.Add("009", "Aamir Pare");

            if (ht.ContainsValue("Aamir Pare"))
            {
                Console.WriteLine("This student name is already in the list");
            }
            else
            {
                ht.Add("008", "Nuha Ali");
            }

            // Get a collection of the keys.
            ICollection keys = ht.Keys;
           
            foreach (string k in keys)
            {
                Console.WriteLine(k + ": " + ht[k]);
            }

            Console.WriteLine("Values.....");

            foreach (var v in ht.Values)
            {
                Console.WriteLine(v + " " );
            }
        }
        public void SortedListDemo()
        {
            SortedList sl = new SortedList();
           
            sl.Add("103", "Kiren Manika");
            sl.Add("100", "Roshan Asad");
            sl.Add("102", "Anglina Johnson");
            sl.Add("109", "Veronika Alleot");
            sl.Add("104", "Mubashir Kazmi");
            sl.Add("107", "Asad Rabbani Khan");
            sl.Add("101", "Rehimullah Yousuf Zaie");

            if (sl.ContainsValue("Nushad Ahmed"))
            {
                Console.WriteLine("This student name is already in the list");
            }
            else
            {
                sl.Add("108", "Nushad Ahmed");
            }

            // get a collection of the keys. 
            ICollection key = sl.Keys;

            foreach (string k in key)
            {
                Console.WriteLine(k + ": " + sl[k]);
            }
        }
        public void StackDemo()
        {
            Stack st = new Stack();

            st.Push('A');
            st.Push('M');
            st.Push('G');
            st.Push('W');

            Console.WriteLine("Current stack: ");
            foreach (char c in st)
            {
                Console.Write(c + " ");
            }
            Console.WriteLine();

            st.Push('V');
            st.Push('H');
            Console.WriteLine("The next poppable value in stack: {0}", st.Peek());
            Console.WriteLine("Current stack: ");

            foreach (char c in st)
            {
                Console.Write(c + " ");
            }

            Console.WriteLine();

            Console.WriteLine("Removing values ");
            st.Pop();
            st.Pop();
            st.Pop();

            Console.WriteLine("Current stack: ");
            foreach (char c in st)
            {
                Console.Write(c + " ");
            }
        }
        public void QueueDemo()
        {
            Queue q = new Queue();

            q.Enqueue('A');
            q.Enqueue('M');
            q.Enqueue('G');
            q.Enqueue('W');

            Console.WriteLine("Current queue: ");
            foreach (char c in q) Console.Write(c + " ");

            Console.WriteLine();
            q.Enqueue('V');
            q.Enqueue('H');
            Console.WriteLine("Current queue: ");
            foreach (char c in q) Console.Write(c + " ");

            Console.WriteLine();
            Console.WriteLine("Removing some values ");
            char ch = (char)q.Dequeue();
            Console.WriteLine("The removed value: {0}", ch);
            ch = (char)q.Dequeue();
            Console.WriteLine("The removed value: {0}", ch);
        }
    }

    public class CollectionsDemo
    {
        public static void Main_collections( string [] args)
        {
            Collections cols = new Collections();
            //cols.ArrayListDemo();
            //cols.HashTableDemo();
            //cols.SortedListDemo();
            //Console.ReadKey();
            CollectionMenu();
            Console.ReadKey();
        }
        static void CollectionMenu()
        {
            Collections cols = new Collections();
            while (true)
            {
                Console.WriteLine("\n");
                Console.WriteLine("Collections in C#");
                Console.WriteLine("1. Array List");
                Console.WriteLine("2. Hashtable");
                Console.WriteLine("3. Sorted List");
                Console.WriteLine("4. Stack");
                Console.WriteLine("5. Queue");
                Console.WriteLine("6. Exit Program");
                Console.Write("Enter Choice : ");
                var choice = int.Parse(Console.ReadLine());
                Console.Clear();
                switch (choice)
                {
                    case 1:
                        cols.ArrayListDemo();
                        break;
                    case 2:
                        cols.HashTableDemo();
                        break;
                    case 3:
                        cols.SortedListDemo();
                        break;
                    case 4:
                        cols.StackDemo();
                        break;
                    case 5:
                        cols.QueueDemo();
                        break;
                    case 6:
                        Environment.Exit(0);
                        break;

                }
            }
        }
    }
}
