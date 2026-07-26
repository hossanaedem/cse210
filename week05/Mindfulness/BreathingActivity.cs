using System;

public class BreathingActivity : Activity
{
    // Constructor
    public BreathingActivity()
        : base(
            "Breathing Activity",
            "This activity will help you relax by guiding you through breathing in and out slowly. Clear your mind and focus on your breathing.")
    {
    }

    // Runs the breathing activity
    public void Run()
    {
        // Display the common starting message
        DisplayStartingMessage();

        Console.Clear();
        Console.WriteLine("Let's begin...");
        Console.WriteLine();

        DateTime endTime = DateTime.Now.AddSeconds(_duration);

        while (DateTime.Now < endTime)
        {
            Console.Write("Breathe in... ");
            ShowCountdown(4);

            if (DateTime.Now >= endTime)
            {
                break;
            }

            Console.Write("Breathe out... ");
            ShowCountdown(6);

            Console.WriteLine();
        }

        // Display the common ending message
        DisplayEndingMessage();
    }
}