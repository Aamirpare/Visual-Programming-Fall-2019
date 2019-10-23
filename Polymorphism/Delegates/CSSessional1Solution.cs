using System.Collections.Generic;

namespace Polymorphism.Delegates
{
    using System;

    /*
        Change the code so that the cricket users can get events
        of updated current score and average score.
        Note: Implement delegates and events
    */

    /* The Solution */
    namespace Polymorphism.Delegates
    {
        //The publisher class
        public class CricketData
        {
            //data fields
            private int Runs { get; set; }
            private int Wickets { get; set; }
            private float Overs { get; set; }

            private readonly List<CricketUser> Subscribers = new List<CricketUser>();
            // Constructor 
            public CricketData(int r = 90, int w = 2, float o = 10.4f)
            {
                this.Runs = r;
                this.Wickets = w;
                this.Overs = o;
            }
            public void DataChanged()
            {
                //Latest update
                this.Runs = 100;
                this.Wickets = 3;
                this.Overs = 23.5f;

                //Display latest update
                NotifyChanges();

                //CurrentScoreDisplay();
                //AverageScoreDisplay();
            }
            //This method publish CurrentScoreDisplay and AverageScoreDisplay 
            //Notifications to the Observer/Subscriber
            private void NotifyChanges()
            {
                //publish changes to observers/subscribers
                foreach (var subscriber in Subscribers)
                {
                    Console.WriteLine($"Score Sent to : { subscriber.UserName }");
                    subscriber.Notify(new Action[] 
                    { 
                        this.CurrentScoreDisplay, 
                        this.AverageScoreDisplay 
                    });
                }

            }
            public void AverageScoreDisplay()
            {
                var runRate = (float)Runs / Overs;
                var predictedScore = (int)(runRate * 50);

                Console.WriteLine($"{"".PadLeft(5)}Average Score Display { Environment.NewLine }" +
                                  $"{"".PadLeft(10)}Run Rate: { runRate.ToString("##.##") } " + Environment.NewLine +
                                  $"{"".PadLeft(10)}Predicted Score: { predictedScore }" + Environment.NewLine);
            }
            public void CurrentScoreDisplay()
            {
                Console.WriteLine($"{"".PadLeft(5)}Current Score Display" + Environment.NewLine +
                                  $"{"".PadLeft(10)}Runs: " + Runs + Environment.NewLine +
                                  $"{"".PadLeft(10)}Wickets: {Wickets}" + Environment.NewLine +
                                  $"{"".PadLeft(10)}Overs: { Overs}" + Environment.NewLine);
            }
            public void Subscribe(CricketUser user)
            {
                Subscribers.Add(user);
            }
            public bool UnSubscribe(CricketUser user)
            {
                return Subscribers.Remove(user);
            }
        }
        // The Subscriber class 
        public class CricketUser
        {
            public event EventHandler<EventArgs> ScoreSent;
            public string UserName { get; set; }
            public string Email { get; set; }
            protected virtual void OnScoreSent()
            {
                ScoreSent?.Invoke(this, EventArgs.Empty);
            }
            
            ////Raise event
            //public void Notify(CricketData cricketData)
            //{
            //    Console.WriteLine($"Scrore sent to : {UserName}");

            //    cricketData.AverageScoreDisplay();
            //    cricketData.CurrentScoreDisplay();

            //    ScoreSent();
            //}
            public void Notify(Action [] nofications)
            {
                if (nofications != null)
                {
                    foreach (var action in nofications)
                    {
                        action();
                    }
                }
                OnScoreSent();
            }
        }

        //The Driver class
        public static class CricketDemoApp
        {
            public static void Main_ddd(String[] args)
            {
                // Pass the displays to Cricket data 
                CricketData cricketData = new CricketData();
                cricketData.Subscribe(new CricketUser
                {
                    Email = "Aamirpare@gmail.com",
                    UserName = "Aamir Pare"
                });

                cricketData.Subscribe(new CricketUser
                {
                    Email = "anwar@gmail.com",
                    UserName = "Anwar Shaukat"
                });

                cricketData.Subscribe(new CricketUser
                {
                    Email = "arshad@yahoo.com",
                    UserName = "Arshad Khan"
                });

                //Show Cricket Update 
                cricketData.DataChanged();

                Console.ReadKey();
            }

        }

    }
}
