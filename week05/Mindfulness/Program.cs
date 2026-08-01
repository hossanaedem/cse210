using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        /*
         * Creativity:
         * This program exceeds the core requirements by:
         * 1. Keeping a history of every activity completed.
         * 2. Tracking the total number of activities completed.
         * 3. Tracking the total amount of time spent practicing mindfulness
         *    during the current session.
         */

        bool isRunning = true;

        int activitiesCompleted = 0;
        int totalMindfulnessTime = 0;

        List<string> activityHistory = new List<string>();

        while (isRunning)
        {
            Console.Clear();

            Console.WriteLine("=======================================");
            Console.WriteLine("        Mindfulness Program");
            Console.WriteLine("=======================================");
            Console.WriteLine();

            Console.WriteLine("Menu Options:");
            Console.WriteLine("1. Start Breathing Activity");
            Console.WriteLine("2. Start Reflection Activity");
            Console.WriteLine("3. Start Listing Activity");
            Console.WriteLine("4. Quit");
            Console.WriteLine();

            Console.Write("Select a choice from the menu: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":

                    BreathingActivity breathingActivity = new BreathingActivity();
                    breathingActivity.Run();

                    activitiesCompleted++;
                    totalMindfulnessTime += breathingActivity.GetDuration();
                    activityHistory.Add("Breathing Activity");

                    break;

                case "2":

                    ReflectionActivity reflectionActivity = new ReflectionActivity();
                    reflectionActivity.Run();

                    activitiesCompleted++;
                    totalMindfulnessTime += reflectionActivity.GetDuration();
                    activityHistory.Add("Reflection Activity");

                    break;

                case "3":

                    ListingActivity listingActivity = new ListingActivity();
                    listingActivity.Run();

                    activitiesCompleted++;
                    totalMindfulnessTime += listingActivity.GetDuration();
                    activityHistory.Add("Listing Activity");

                    break;

                case "4":

                    isRunning = false;

                    break;

                default:

                    Console.WriteLine();
                    Console.WriteLine("Invalid choice. Please try again.");
                    Console.WriteLine("Press Enter to continue...");
                    Console.ReadLine();

                    break;
            }
        }

        Console.Clear();

        Console.WriteLine("=======================================");
        Console.WriteLine("         SESSION SUMMARY");
        Console.WriteLine("=======================================");
        Console.WriteLine();

        Console.WriteLine($"Activities Completed : {activitiesCompleted}");
        Console.WriteLine($"Total Mindfulness Time : {totalMindfulnessTime} seconds");

        Console.WriteLine();

        if (activityHistory.Count > 0)
        {
            Console.WriteLine("Activities Performed:");

            for (int i = 0; i < activityHistory.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {activityHistory[i]}");
            }
        }
        else
        {
            Console.WriteLine("No activities were completed.");
        }

        Console.WriteLine();
        Console.WriteLine("Thank you for using the Mindfulness Program!");
        Console.WriteLine("Press Enter to exit...");
        Console.ReadLine();
    }
}