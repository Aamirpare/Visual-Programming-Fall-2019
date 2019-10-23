using System;

/*
    Change the code so that the cricket users can get events
    of updated current score and average score.
    Note: Implement delegates and events
*/

namespace Polymorphism.Delegates
{
    class CricketData
    {
        //data fields
        private int Runs { get; set; }
        private int Wickets { get; set; }
        private float Overs { get; set; }

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
        public static void Main_sessional_BSCS_7B(String[] args)
        {
            // Pass the displays to Cricket data 
            CricketData cricketData = new CricketData();

            //Show Cricket Update 
            cricketData.DataChanged();

            Console.ReadKey();
        }
    }

}
