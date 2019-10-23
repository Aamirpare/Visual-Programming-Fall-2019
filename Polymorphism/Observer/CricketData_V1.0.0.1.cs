/*
    Author      : Aamir Shabbir Pare
    Description : Writing Clean Code by applying object oriented principles
                : and Desing Patterns
    Example     : A real world cricket game application
    Version     : V.1.0.0.1
    Changes     : Break into multiple class (Single Responsibility Pricipal)
    Date        : Oct 13, 2019
    Location    : G-11/2 Home, Islamabad
*/

using System;

namespace Polymorphism.Observer.V1
{
    class CricketData
    {
        //data fields
        public int Runs { get; set; }
        private int Wickets { get; set; }
        private float Overs { get; set; }

        CurrentScoreDisplay currentScoreDisplay;
        AverageScoreDisplay averageScoreDisplay;

        // Constructor 
        public CricketData(CurrentScoreDisplay currentScoreDisplay,
                           AverageScoreDisplay averageScoreDisplay)
        {
            this.currentScoreDisplay = currentScoreDisplay;
            this.averageScoreDisplay = averageScoreDisplay;
        }

        // Get latest runs from stadium
        public int LatestRuns { get; set; } = 90;

        // Get latest wickets from stadium 
        private int LatestWickets { get; set; } = 2;

        // Get latest overs from stadium 
        private float LatestOvers { get; set; } = 10.2f;

        // This method is used update displays when data changes 
        public void dataChanged()
        {
            // get latest data 
            Runs = LatestRuns;
            Wickets = LatestWickets;
            Overs = LatestOvers;

            currentScoreDisplay.update(Runs, Wickets, Overs);
            averageScoreDisplay.update(Runs, Wickets, Overs);
        }
    }

    // A class to display average score. Data of this class is 
    // updated by CricketData 
    class AverageScoreDisplay
    {
        private float runRate;
        private int predictedScore;

        public void update(int runs, int wickets, float overs)
        {
            this.runRate = (float)runs / overs;
            this.predictedScore = (int)(this.runRate * 50);
            Display();
        }

        public void Display()
        {
            Console.WriteLine($"{ Environment.NewLine }Average Score Display { Environment.NewLine }" +
                              $"Run Rate: { runRate } " + Environment.NewLine +
                              $"Predicted Score: { predictedScore }");
        }
    }

    // A class to display score. Data of this class is 
    // updated by CricketData 
    class CurrentScoreDisplay
    {
        private int runs, wickets;
        private float overs;

        public void update(int runs, int wickets, float overs)
        {
            this.runs = runs;
            this.wickets = wickets;
            this.overs = overs;
            Display();
        }

        public void Display()
        {
            Console.WriteLine($"{Environment.NewLine}Current Score Display" + Environment.NewLine +
                              $"Runs: " + runs + Environment.NewLine + 
                              $"Wickets: {wickets}" + Environment.NewLine +
                              $"Overs: { overs}");
        }
    }

    // Driver class 
    public static class CricketDemoApp
    {
        public static void Main_Cricket_V1(String [] args)
        {
            // Create objects for testing 
            AverageScoreDisplay averageScoreDisplay =
                                           new AverageScoreDisplay();
            CurrentScoreDisplay currentScoreDisplay =
                                           new CurrentScoreDisplay();

            // Pass the displays to Cricket data 
            CricketData cricketData = new CricketData(currentScoreDisplay,
                                                      averageScoreDisplay);

            // In real app you would have some logic to call this 
            // function when data changes 
            cricketData.dataChanged();

            Console.ReadKey();
        }
    }
}
/*
Problems with above design:

1.  CricketData holds references to concrete display element objects even though it needs
    to call only the update method of these objects. It has access to too much additional
    information than it requires.
2.  This statement “currentScoreDisplay.update(runs,wickets,overs);” violates one of the 
    most important design principle “Program to interfaces, not implementations.” as we 
    are using concrete objects to share data rather than abstract interfaces.
3.  CricketData and display elements are tightly coupled.
4.  If in future another requirement comes in and we need another display element to be 
    added we need to make changes to the non-varying part of our code(CricketData). 
    This is definitely not a good design practice and application might not be able to 
    handle changes and not easy to maintain. 

Question  : How to avoid these problems?
Answer    : Use Observer Pattern
Reference : See the V.0.0.2  
*/

