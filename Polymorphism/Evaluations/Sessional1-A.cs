/*
    Author      : Aamir Shabbir Pare
    Description : Solution for Sessional-1 BSSE 6A
    Example     : A real world publisher/Subscriber application
    Date        : Oct 22, 2019, @ 1430 - 1600 Hrs
    Location    : Room # G05, Block AB02
                  Department Computer Science
                  COMSATS University
                  Check Shehzad Islamabad
    Comment     : The solution to the problem given in Fall 2019 sessional exam 
*/

using System;
using System.Collections.Generic;
using System.Linq;

namespace Polymorphism.Fall2019
{
    public class Magazine
    {
        public string Title { get; set; }
        public int Pages { get; set; }
        public string Content { get; set; }
    }
    public class Reader
    {
        public event Action<Magazine> Received;
        public string FullName { get; set; }
        public string Email { get; set; }
        protected virtual void OnReceived(Magazine magazine)
        {
            Received?.Invoke(magazine);
        }

        public void Receive(Magazine magazine)
        {
            this.OnReceived(magazine);
        }

    }
    public class HyperMedia
    {
        private List<Reader> Subscribers { get; }
        public HyperMedia()
        {
            Subscribers = new List<Reader>();
        }
        public void Subscribe(Reader reader)
        {
            Subscribers.Add(reader);
        }
        public bool UnSubscribe(Reader reader)
        {
            return Subscribers.Remove(reader);
        }
        public void Publish()
        {
            var magazine = new Magazine()
            {
                Title = "Hyper Media IT Magazine",
                Pages = 130,
                Content = "Frontiers of IT,IT Solutions in AI,Robotics in Medical Engineering,Future of Data Science"
            };
            //After publishing, send magazine to the subscribers
            this.SendMagazine(magazine);
        }
        private void SendMagazine(Magazine magazine)
        {
            foreach (var reader in Subscribers)
            {
                Console.WriteLine($"Magazine sent to : {reader.FullName}");
                reader.Receive(magazine);
            }
        }
    }
    public static class HyperMediaDemo
    {
        static void Main_Session1_A(string[] args)
        {
            HyperMedia publisher = new HyperMedia();
            
            var subscriber1 = new Reader()
            {
                FullName = "Dr. Nishar Khan",
                Email = "nisar.khan@gmail.com"
            };
            var subscriber2 = new Reader()
            {
                FullName = "Dr. Tahir Musa",
                Email = "tahir.musa@gmail.com",
            };
            var subscriber3 = new Reader()
            {
                FullName = "Dr. Sara Nisar",
                Email = "sara.nisar@gmail.com",
            };

            publisher.Subscribe(subscriber1);
            publisher.Subscribe(subscriber2);
            publisher.Subscribe(subscriber3);

            subscriber1.Received += ShowMegazine;
            subscriber2.Received += ShowMegazine;
            subscriber3.Received += ShowMegazine;

            publisher.Publish();

            Console.ReadKey();
        }   
        private static void ShowMegazine(Magazine m)
        {
            var contents = m.Content.Split(',').ToList();
            Console.WriteLine($"Title : {m.Title}");
            Console.WriteLine($"Pages : {m.Pages}");
            Console.WriteLine($"Content :");
            contents.ForEach(c => Console.WriteLine("".PadLeft(8) + c));
        }
       
    }
}
