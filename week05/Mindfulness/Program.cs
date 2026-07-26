using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Creativity:
        // This program exceeds the core requirements by keeping track of
        // all activities completed during the session. When the user exits,
        // the program displays the total number of completed activities
        // along with the names of the activities completed.

        bool running = true;

        int activitiesCompleted = 0;

        List<string> activityHistory = new List<string>();

        while (running)
        {
            Console.Clear();

            Console.WriteLine("=========================================");
            Console.WriteLine("        Mindfulness Program");
            Console.WriteLine("=========================================");
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

                    BreathingActivity breathing = new BreathingActivity();
                    breathing.Run();

                    activitiesCompleted++;
                    activityHistory.Add("Breathing Activity");

                    break;

                case "2":

                    ReflectionActivity reflection = new ReflectionActivity();
                    reflection.Run();

                    activitiesCompleted++;
                    activityHistory.Add("Reflection Activity");

                    break;

                case "3":

                    ListingActivity listing = new ListingActivity();
                    listing.Run();

                    activitiesCompleted++;
                    activityHistory.Add("Listing Activity");

                    break;

                case "4":

                    running = false;

                    break;

                default:

                    Console.WriteLine();
                    Console.WriteLine("Invalid option. Please try again.");
                    Console.WriteLine("Press Enter to continue...");
                    Console.ReadLine();

                    break;
            }
        }

        Console.Clear();

        Console.WriteLine("=========================================");
        Console.WriteLine("      Session Summary");
        Console.WriteLine("=========================================");
        Console.WriteLine();

        Console.WriteLine($"Activities Completed: {activitiesCompleted}");

        if (activitiesCompleted > 0)
        {
            Console.WriteLine();
            Console.WriteLine("Activities Performed:");

            foreach (string activity in activityHistory)
            {
                Console.WriteLine($"- {activity}");
            }
        }

        Console.WriteLine();
        Console.WriteLine("Thank you for using the Mindfulness Program!");
    }
}