/*
    Instructor  :   Aamir Parre
    Description :   Implementation of Observer Design Pattern Using Delegates & Events
    Class       :   BSCS-6 (Section A, B)
    Course      :   Visual Programming
    Date        :   22th September, 2019
    Location    :   G-11/2 Home, Islamabad
    Work Hours  :   Analysis 2 Hours, 
                    Implementation 1.2 Hours V.1.0.0.0,
                    Optimizations  20 Minutes V.1.0.0.1,
                    
*/

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polymorphism.Events
{
    public delegate void DataChangeHandler(object sender, EventArgs e);
    public interface IObserver
    {
        void Update(int runs, int wickets, float overs);
    }
    public interface ISubject
    {
        event DataChangeHandler DataChanged;
        void Register(IObserver observer);
        void UnRegister(IObserver observer);
        void Notify();
        void UpdateStastics(int runs, int wickets, float overs);
    }
    public class CricketData : ISubject
    {
        public event DataChangeHandler DataChanged;
        private int Runs { get; set; }
        private int Wickets { get; set; }
        private float Overs { get; set; }

        readonly List<IObserver> Observers = new List<IObserver>();
        public void Notify()
        {
            Observers.ForEach(o => o.Update(Runs, Wickets, Overs));
        }

        public void Register(IObserver observer)
        {
            Observers.Add(observer);
        }

        public void UnRegister(IObserver observer)
        {
            Observers.Remove(observer);
        }

        protected virtual void OnDataChanged()
        {
            this.DataChanged?.Invoke(this, EventArgs.Empty);
        }
        public void UpdateStastics(int runs, int wickets, float overs)
        {
            this.Runs = runs;
            this.Wickets = wickets;
            this.Overs = overs;

            this.Notify();

            OnDataChanged();
        }

    }
    public class AverageScoreDisplay : IObserver
    {
        private float RunRate { get; set; }
        private int PredictedScore { get; set; }

        public void Update(int runs, int wickets, float overs)
        {
            this.RunRate = (float)runs / overs;
            this.PredictedScore = (int)(this.RunRate * 50);
            Display();
        }

        public void Display()
        {
            Console.WriteLine("\nAverage Score Display: \n"
                               + "Run Rate: " + RunRate +
                               "\nPredicted Score: " +
                               PredictedScore);
        }
    }
    public class CurrentScoreDisplay : IObserver
    {
        private int Runs { get; set; }
        private int Wickets { get; set; }
        private float Overs { get; set; }
        public void Update(int runs, int wickets, float overs)
        {
            this.Runs = runs;
            this.Wickets = wickets;
            this.Overs = overs;
            Display();
        }
        public void Display()
        {
            Console.WriteLine("\nCurrent Score Display:\n"
                       + "Runs: " + this.Runs +
                       "\nWickets:" + this.Wickets +
                       "\nOvers: " + this.Overs);
        }
    }
    public interface ICriketDataFactory
    {
        IObserver CreateAverageScoreObserver();
        IObserver CreateCurrentScoreObserver();
        ISubject CreateCricketDataSubject();
    }
    public class CriketDataFactory : ICriketDataFactory
    {
        public IObserver CreateAverageScoreObserver()
        {
            return new AverageScoreDisplay();
        }

        public IObserver CreateCurrentScoreObserver()
        {
            return new CurrentScoreDisplay();
        }

        public ISubject CreateCricketDataSubject()
        {
            return new CricketData();
        }
    }
    public class ObserverDemo
    {
        public static void Main_Observer(string[] args)
        {
            CreateTest();
            Console.ReadKey();
        }
        public static void CreateTest()
        { 
            ICriketDataFactory factory = new CriketDataFactory();
            // create objects for testing 
            IObserver averageScoreDisplay = factory.CreateAverageScoreObserver();
            IObserver currentScoreDisplay = factory.CreateCurrentScoreObserver();

            // pass the displays to Cricket data 
            ISubject cricketData = factory.CreateCricketDataSubject();
            cricketData.DataChanged += CricketData_DataChanged;

            void CricketData_DataChanged(object sender, EventArgs e)
            {
                Console.WriteLine("Score Changed. Inner event handler");
            }

            // register display elements 
            cricketData.Register(averageScoreDisplay);
            cricketData.Register(currentScoreDisplay);

            // in real app you would have some logic to 
            // call this function when data changes 
            Console.WriteLine("All observers get the notification - first change");
            cricketData.UpdateStastics(10, 1, 5.3f);

            //remove an observer 
            cricketData.UnRegister(averageScoreDisplay);

            // now only currentScoreDisplay gets the 
            // notification 
            Console.WriteLine("\nOnly currentScoreDisplay gets the notification - second change");
            cricketData.UpdateStastics(20,2, 6.5f);

        }
        private static void CricketData_DataChanged(object sender, EventArgs e)
        {
            Console.WriteLine("Score Changed. Outer event handler");
        }

    }
}
