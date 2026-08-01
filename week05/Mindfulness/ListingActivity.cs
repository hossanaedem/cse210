using System;
using System.Collections.Generic;

public class ListingActivity : Activity
{
    private List<string> _prompts;
    private Random _random;

    // Constructor
    public ListingActivity()
        : base(
            "Listing Activity",
            "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {
        _random = new Random();

        _prompts = new List<string>
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };
    }

    // Returns a random prompt
    private string GetRandomPrompt()
    {
        int index = _random.Next(_prompts.Count);
        return _prompts[index];
    }

    // Runs the listing activity
    public void Run()
    {
        DisplayStartingMessage();

        Console.Clear();

        Console.WriteLine("List as many responses as you can to the following prompt:");
        Console.WriteLine();

        Console.WriteLine($"--- {GetRandomPrompt()} ---");

        Console.WriteLine();
        Console.WriteLine("You may begin in:");
        ShowCountdown(5);

        Console.WriteLine();

        List<string> userItems = new List<string>();

        DateTime endTime = DateTime.Now.AddSeconds(_duration);

        while (DateTime.Now < endTime)
        {
            Console.Write("> ");

            string item = Console.ReadLine();

            // Check if time expired while the user was typing
            if (DateTime.Now > endTime)
            {
                break;
            }

            if (!string.IsNullOrWhiteSpace(item))
            {
                userItems.Add(item);
            }
        }

        Console.WriteLine();
        Console.WriteLine($"You listed {userItems.Count} items!");

        DisplayEndingMessage();
    }
}