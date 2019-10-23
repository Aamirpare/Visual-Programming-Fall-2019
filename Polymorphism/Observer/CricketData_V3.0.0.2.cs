/*
    Author      : Aamir Shabbir Pare
    Description : Writing Clean Code by applying object oriented principles
                : and Desing Patterns
    Example     : A real world cricket game application
    Version     : V.3.0.0.2
    Changes     : Applying Factory Pattern
    Date        : Oct 13, 2019
    Location    : G-11/2 Home, Islamabad
*/
using System;
using System.Collections.Generic;

namespace Polymorphism.Observer.V32
{
    public class CricketData
    {
        public int Runs { get; set; }
        public float Overs { get; set; }
        public int Wickets { get; set; }
        public int TotalOvers { get; set; } = 50;
    }
    public interface ICricketSubject
    {
        /// <summary>
        /// Subscribes the observer
        /// </summary>
        /// <param name="observer"></param>
        void Subscribe(ICricketObserver observer);
        /// <summary>
        /// UnSubscribes the obeserver
        /// </summary>
        /// <param name="observer"></param>
        void UnSubscribe(ICricketObserver observer);
        /// <summary>
        /// Notify changes to all observers who have subscribed
        /// </summary>
        void Update();

        /// <summary>
        /// This event will fire when the observer Subscribes
        /// </summary>
        event EventHandler<EventArgs> Subscribed;

        /// <summary>
        /// This event will fire when the observer UnSubscribes
        /// </summary>
        event EventHandler<EventArgs> UnSubscribed;
        void Next(Action<CricketData> initialize);
    }
    public interface ICricketFactory
    {
        IList<ICricketObserver> CreateObserverList();
        ICricketObserver CreateAverageScoreDisplay();
        ICricketObserver CreateCurrentScoreDisplay();
        ICricketSubject CreateCicketSubject(Action<CricketData> create);
    }
    public class CricketFactory : ICricketFactory
    {
        public ICricketObserver CreateAverageScoreDisplay()
        {
            return new AverageScoreDisplay();
        }
        public ICricketSubject CreateCicketSubject(Action<CricketData> options)
        {
            var cricketData = new CricketData();
            options(cricketData);
            return new CricketSubject(cricketData);
        }
        public ICricketObserver CreateCurrentScoreDisplay()
        {
            return new CurrentScoreDisplay();
        }
        public IList<ICricketObserver> CreateObserverList()
        {
            return new List<ICricketObserver>();
        }
    }
    public class CricketSubject : ICricketSubject
    {
        /// <summary>
        /// This event will fire when the observer Subscribes
        /// </summary>
        public event EventHandler<EventArgs> Subscribed;

        /// <summary>
        /// This event will fire when the observer UnSubscribes
        /// </summary>
        public event EventHandler<EventArgs> UnSubscribed;
        /// <summary>
        /// Subject Cricket data 
        /// </summary>
        public CricketData CricketData { get; private set; }

        /// <summary>
        /// In-memory Observers list
        /// </summary>
        public IList<ICricketObserver> Observers { get; set; }

        private readonly ICricketFactory factory = new CricketFactory();
        public CricketSubject()
        {
            //Create a new observers list
            Observers = factory.CreateObserverList();
        }
        public CricketSubject(CricketData cricketData):this()
        {
            CricketData = cricketData;
        }
        public void Next(Action<CricketData> initialize)
        {
            var cricketData = new CricketData();
            initialize(cricketData);
            CricketData = cricketData;
        }
        public void Subscribe(ICricketObserver observer)
        {
            Observers.Add(observer);
            OnSubscribe();
        }
        public void UnSubscribe(ICricketObserver observer)
        {
            Observers.Remove(observer);
            OnUnSubscribe();
        }
        public void Update()
        {
            foreach (var o in Observers)
            {
                o.Update(CricketData);
            }
        }
        protected virtual void OnSubscribe()
        {
            EventHandler<EventArgs> handler = Subscribed;
            handler?.Invoke(this, EventArgs.Empty);
        }
        protected virtual void OnUnSubscribe()
        {
            EventHandler<EventArgs> handler = UnSubscribed;
            handler?.Invoke(this, EventArgs.Empty);
        }
    }
    public interface ICricketObserver
    {
        /// <summary>
        /// Updates the cricket data and displays results
        /// </summary>
        /// <param name="cricketData"></param>
        void Update(CricketData cricketData);

        /// <summary>
        /// This event will fire whenever there is a an update
        /// </summary>
        event EventHandler<EventArgs> Notify;
    }
    public class CurrentScoreDisplay : ICricketObserver
    {
        public event EventHandler<EventArgs> Notify;
        private CricketData CricketData { set; get; }
        public void Update(CricketData cricketData)
        {
            CricketData = cricketData;
            Display();
            OnNotify();
        }
        protected virtual void OnNotify()
        {
            EventHandler<EventArgs> handler = Notify;
            handler?.Invoke(this, EventArgs.Empty);
        }
        private void Display()
        {
            Console.WriteLine("");
            Console.WriteLine($"Runs : {this.CricketData.Runs}");
            Console.WriteLine($"Wickets : {this.CricketData.Wickets}");
            Console.WriteLine($"Overs : {this.CricketData.Overs}");
            Console.WriteLine($"Remaining Overs : {this.CricketData.TotalOvers - this.CricketData.Overs}");
            Console.WriteLine($"Total Overs : {this.CricketData.TotalOvers}");

            Console.WriteLine("");
        }
    }
    public class AverageScoreDisplay : ICricketObserver
    {
        public event EventHandler<EventArgs> Notify;
        private float RunRate { set; get; }
        private int PridictedScore { set; get; }
        public void Update(CricketData cricketData)
        {
            this.RunRate = (float)cricketData.Runs / cricketData.Overs;
            this.PridictedScore = (int)this.RunRate * cricketData.TotalOvers;
            Display();
            OnNotify();
        }
        public virtual void OnNotify()
        {
            Notify?.Invoke(this, EventArgs.Empty);
        }
        private void Display()
        {
            Console.WriteLine($"Run Rate : {this.RunRate.ToString("##.##")}");
            Console.WriteLine($"Predicted Score : {this.PridictedScore}");
            Console.WriteLine("");
        }
    }
    public static class CricketDemoApp
    {
        public static void Main_observer_V32(string[] args)
        {
            ICricketFactory iFactory = new CricketFactory();
            // Create objects for testing 
            ICricketObserver iAverageScoreDisplay = iFactory.CreateAverageScoreDisplay();
            iAverageScoreDisplay.Notify += AverageScoreDisplay_Notify;

            ICricketObserver iCurrentScoreDisplay = iFactory.CreateCurrentScoreDisplay();
            iCurrentScoreDisplay.Notify += CurrentScoreDisplay_Notify;

            // Create Cricket Subject and pass initial data 
            ICricketSubject cricketSubject = iFactory.CreateCicketSubject( 
            (o) => {
                o.Runs = 100;
                o.Wickets = 3;
                o.Overs = 22.3f;
            });

            ICricketSubject iCricketSubject = cricketSubject;
            iCricketSubject.Subscribed += CricketSubject_Subscribed;

            //Register display elements 
            iCricketSubject.Subscribe(iCurrentScoreDisplay);
            iCricketSubject.Subscribe(iAverageScoreDisplay);
            
            
            //In real app you would have some logic to 
            //call this function when data changes 
            iCricketSubject.Update();

            //Remove an observer 
            iCricketSubject.UnSubscribed += CricketSubject_UnSubscribed;
            iCricketSubject.UnSubscribe(iAverageScoreDisplay);

            cricketSubject.Next( 
            (o) => 
            {
                o.Runs = 135;
                o.Wickets = 4;
                o.Overs = 26.2f;
            });
            
            iCricketSubject = cricketSubject;

            // Now only currentScoreDisplay gets the notification 
            iCricketSubject.Update();
            Console.ReadKey();
        }
        private static void CricketSubject_Subscribed(object sender, EventArgs e)
        {
            Console.WriteLine("You have subscribed the service.");
        }
        private static void CricketSubject_UnSubscribed(object sender, EventArgs e)
        {
            Console.WriteLine("You have unsubscribed the service.");
        }
        private static void CurrentScoreDisplay_Notify(object sender, EventArgs e)
        {
            Console.WriteLine("Current display observed notification..." + Environment.NewLine);
        }
        private static void AverageScoreDisplay_Notify(object sender, EventArgs e)
        {
            Console.WriteLine("Average display observed notification..." + Environment.NewLine);
        }
    }
}
