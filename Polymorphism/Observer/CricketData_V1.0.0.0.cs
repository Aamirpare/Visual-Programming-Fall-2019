/*
    Author      : Aamir Shabbir Pare
    Description : Writing Clean Code by applying object oriented principles
                : and Desing Patterns
    Example     : A real world cricket game application
    Version     : V.1.0.0.0
    Date        : Oct 13, 2019
    Location    : G-11/2 Home, Islamabad
    Comment     : The code in this example is a simple cricket score application
                  which i my experiece the students not go beyound further to 
                  implement the power of object oriented software engineering.
                  Objective of creating this long exercise is to help students, 
                  instructors, and developers write extensible, mantainable,
                  extendble and clean code. 
*/

using System;
namespace Polymorphism.Observer.V0
{
    class CricketData
    {
        //data fields
        public int Runs { get; set; }
        private int Wickets { get; set; }
        private float Overs { get; set; }

        // Constructor 
        public CricketData(int r=90, int w=2, float o=10.4f)
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
            CurrentScoreDisplay();
            AverageScoreDisplay();
        }
        public void AverageScoreDisplay()
        {
            var runRate = (float)Runs / Overs;
            var predictedScore = (int)(runRate * 50);

            Console.WriteLine($"{ Environment.NewLine }Average Score Display { Environment.NewLine }" +
                              $"Run Rate: { runRate.ToString("##.##") } " + Environment.NewLine +
                              $"Predicted Score: { predictedScore }");
        }

        public void CurrentScoreDisplay()
        {
            Console.WriteLine($"{Environment.NewLine}Current Score Display" + Environment.NewLine +
                              $"Runs: " + Runs + Environment.NewLine +
                              $"Wickets: {Wickets}" + Environment.NewLine +
                              $"Overs: { Overs}");
        }
    }
    // Driver class 
    public static class CricketDemoApp
    {
        public static void Main_Oberserver_Pattern(String [] args)
        {
            // Pass the displays to Cricket data 
            CricketData cricketData = new CricketData();

            //Show Cricket Update 
            cricketData.DataChanged();

            Console.ReadKey();
        }
    }
}
