/*
    Author      : Aamir Shabbir Pare
    Description : Writing Clean Code by applying object oriented principles
                : and Desing Patterns
    Example     : A real world cricket game application
    Version     : V.3.0.0.0
    Changes     : The problem in v2, it composes cricket data inside CricketSubject.
                  To remove this data and make it a standalone class as CricketData
                  and apply required changes on other places.
                  Thus you make the class independent of future changes. (Lose Coupling)
    Date        : Oct 13, 2019
    Location    : G-11/2 Home, Islamabad
*/

using System;
using System.Collections.Generic;

namespace Polymorphism.Observer.V30
{
    public class CricketData
    {
        public int Runs { get; set; }
        public float Overs { get; set; }
        public int Wickets { get; set; }
        public int TotalOvers { get; set; }
    }
    public interface ICricketSubject
    {
        void Register(ICricketObserver observer);
        void UnRegister(ICricketObserver observer);
        void NotifyObervers();
    }
    public class CricketSubject : ICricketSubject
    {
        public CricketData CricketData { get; set; }
        public List<ICricketObserver> Observers { get; set; }
        public CricketSubject()
        {
            Observers = new List<ICricketObserver>();
        }
        public void NotifyObervers()
        {
            foreach (var o in Observers)
            {
                o.Update(CricketData);
            }
        }

        public void Register(ICricketObserver observer)
        {
            Observers.Add(observer);
        }

        public void UnRegister(ICricketObserver observer)
        {
            Observers.Remove(observer);
        }

        public void ChangeData()
        {
            NotifyObervers();
        }
    }
    public interface ICricketObserver
    {
        void Update(CricketData cricketData);
    }
    public class CurrentScoreDisplay : ICricketObserver
    {
        private CricketData CricketData { set; get; }
        public void Update(CricketData cricketData)
        {
            CricketData = cricketData;
            Display();
        }
        public void Display()
        {
            Console.WriteLine($"Runs : {this.CricketData.Runs}");
            Console.WriteLine($"Wickets : {this.CricketData.Wickets}");
            Console.WriteLine($"Overs : {this.CricketData.Overs}");
            Console.WriteLine("");
        }
    }
    public class AverageScoreDisplay : ICricketObserver
    {
        private float RunRate { set; get; }
        private int PridictedScore { set; get; }
        public void Update(CricketData cricketData)
        {
            this.RunRate = (float)cricketData.Runs / cricketData.Overs;
            this.PridictedScore = (int)this.RunRate * cricketData.TotalOvers;
            Display();
        }

        public void Display()
        {
            Console.WriteLine($"Run Rate : {this.RunRate}");
            Console.WriteLine($"Predicted Score : {this.PridictedScore}");
            Console.WriteLine("");
        }
    }
    public static class CricketDemo
    {
        public static void Main_Observer_V30(string[] args)
        {
            // create objects for testing 
            AverageScoreDisplay averageScoreDisplay =
                              new AverageScoreDisplay();
            CurrentScoreDisplay currentScoreDisplay =
                              new CurrentScoreDisplay();

            CricketData cricketData = new CricketData()
            {
                Runs = 100,
                Wickets = 3,
                Overs = 22.3f
            };
            // pass the displays to Cricket data 
            CricketSubject cricketSubject = new CricketSubject()
            {
                CricketData = cricketData
            };

            // register display elements 
            cricketSubject.Register(averageScoreDisplay);
            cricketSubject.Register(currentScoreDisplay);

            // in real app you would have some logic to 
            // call this function when data changes 
            cricketSubject.ChangeData();

            //remove an observer 
            cricketSubject.UnRegister(averageScoreDisplay);

            // now only currentScoreDisplay gets the 
            // notification 
            cricketSubject.ChangeData();
            Console.ReadKey();
        }
    }

}
