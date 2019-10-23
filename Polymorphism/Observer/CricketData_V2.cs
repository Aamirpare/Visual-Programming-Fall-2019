/*
    Author      : Aamir Shabbir Pare
    Description : Writing Clean Code by applying object oriented principles
                : and Desing Patterns
    Example     : A real world cricket game application
    Version     : V.2.0.0.0
    Changes     : Applying Observer Pattern for (Lose Coupling)
    Date        : Oct 13, 2019
    Location    : G-11/2 Home, Islamabad
*/

using System;
using System.Collections.Generic;

namespace Polymorphism.Observer.V20
{
    public interface ICricketSubject
    {
        void Register(ICricketObserver observer);
        void UnRegister(ICricketObserver observer);
        void NotifyObervers();
    }
    public class CricketData : ICricketSubject
    {
        public int Runs { get; set; }
        public float Overs { get; set; }
        public int Wickets { get; set; }
        public List<ICricketObserver> Observers { get; set; }
        public CricketData()
        {
            Observers = new List<ICricketObserver>();
        }
        public void NotifyObervers()
        {
            foreach (var o in Observers)
            {
                o.Update(Runs, Wickets, Overs);
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
        void Update(int runs, int wickets, float overs);
    }
    public class CurrentScoreDisplay : ICricketObserver
    {
        private int Runs { get; set; }
        private float Overs { get; set; }
        private int Wickets { get; set; }
        public void Update(int runs, int wickets, float overs)
        {
            this.Runs = runs;
            this.Wickets = wickets;
            this.Overs = overs;
            Display();
        }
        public void Display()
        {
            Console.WriteLine($"Runs : {this.Runs}");
            Console.WriteLine($"Wickets : {this.Wickets}");
            Console.WriteLine($"Overs : {this.Overs}");
            Console.WriteLine("");
        }
    }
    public class AverageScoreDisplay : ICricketObserver
    {
        private float RunRate { set; get; }
        private int PridictedScore { set; get; }
        public void Update(int runs, int wickets, float overs)
        {
            this.RunRate = (float)runs / overs;
            this.PridictedScore = (int)this.RunRate * 50;
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
        public static void Main_Observer_V20(string[] args)
        {
            // create objects for testing 
            AverageScoreDisplay averageScoreDisplay =
                              new AverageScoreDisplay();
            CurrentScoreDisplay currentScoreDisplay =
                              new CurrentScoreDisplay();

            // pass the displays to Cricket data 
            CricketData cricketData = new CricketData()
            {
                Runs = 100,
                Wickets = 3,
                Overs = 22.3f
            };

            // register display elements 
            cricketData.Register(averageScoreDisplay);
            cricketData.Register(currentScoreDisplay);

            // in real app you would have some logic to 
            // call this function when data changes 
            cricketData.ChangeData();

            //remove an observer 
            cricketData.UnRegister(averageScoreDisplay);

            // now only currentScoreDisplay gets the 
            // notification 
            cricketData.ChangeData();
            Console.ReadKey();
        }
    }

}
