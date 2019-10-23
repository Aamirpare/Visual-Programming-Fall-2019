/*
    Author      : Aamir Shabbir Pare
    Description : Solution for Sessional-1 BSSE 6B
    Example     : A real world publisher/Subscriber application
    Date        : Oct 23, 2019, @ 1000 - 1130 Hrs
    Location    : Room # 207, Block AB02
                  Department Computer Science
                  COMSATS University
                  Check Shehzad Islamabad
    Comment     : The solution to the problem given in Fall 2019 sessional exam 
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HperMedia
{
    public class Magazine
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public int Pages { get; set; }
    }
    public class Reader
    {
        //public delegate void MagazineHandler(Magazine magazine);
        //public event MagazineHandler Received;

        public event Action<Magazine> Received;
        public string FullName { get; set; }
        public string Email { get; set; }

        protected virtual void OnReceive(Magazine magazine)
        {
            Received?.Invoke(magazine);
            //if (Received != null)
            //{
            //    Received(magazine);
            //}
        }
        public void Receive(Magazine magazine)
        {
            this.OnReceive(magazine);
        }
    }
    public class Publisher
    {
        private List<Reader> Subscribers { get; set; }

        public Publisher()
        {
            Subscribers = new List<Reader>();
        }
        public void Publish()
        {
            //Megazine
            var magazine = new Magazine()
            {
                Title = "IT Informatics",
                Content = "Use of IT in KPK, Academic Information Systems",
                Pages = 80
            };
            Console.WriteLine("A new magazine has been published");

            foreach (var reader in Subscribers)
            {
                Console.WriteLine("Magazine sent...");
                //Console.WriteLine($"Magazine with title : {magazine.Title} is sent to : {reader.FullName}");
                reader.Receive(magazine);
            }
        }

        public void Subscirbe(Reader reader)
        {
            Subscribers.Add(reader);
        }
        public bool UnSubscirbe(Reader reader)
        {
            return Subscribers.Remove(reader);
        }
    }


    class Program
    {
        static void Main_session1_B(string[] args)
        {


            Publisher publisher = new Publisher();

            Reader subscriber1 = new Reader()
            {
                FullName = "Leonardo",
                Email = "leonardo@gmail.com"
            };

            Reader subscriber2 = new Reader()
            {
                FullName = "Sara Khan",
                Email = "sara.khan@gmail.com"
            };
            Reader subscriber3 = new Reader()
            {
                FullName = "Ayesh Khan",
                Email = "Ayesh.khan@gmail.com"
            };

            publisher.Subscirbe(subscriber1);
            publisher.Subscirbe(subscriber2);
            publisher.Subscirbe(subscriber3);


            subscriber1.Received += ShowMagazine;
            subscriber2.Received += ShowMagazine;
            subscriber3.Received += ShowMagazine2;

            publisher.Publish();

            Console.ReadKey();
        }

        private static void ShowMagazine(Magazine magazine)
        {
            Console.WriteLine($"Title : { magazine.Title}");
            Console.WriteLine($"Pages :  { magazine.Pages}");
        }
        private static void ShowMagazine2(Magazine magazine)
        {
            //Console.WriteLine($"Title : { magazine.Title}");
            //Console.WriteLine($"Pages :  { magazine.Pages}");

            foreach (var c in magazine.Content.Split(','))
            {
                Console.WriteLine("".PadLeft(10) + c);
            }
        }
    }
}
