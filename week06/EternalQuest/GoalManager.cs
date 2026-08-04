using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals;
    private int _score;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    public void Start()
    {
        int choice = 0;

        while (choice != 6)
        {
            Console.Clear();
            DisplayPlayerInfo();

            Console.WriteLine();
            Console.WriteLine("Menu Options");
            Console.WriteLine("  1. Create New Goal");
            Console.WriteLine("  2. List Goals");
            Console.WriteLine("  3. Save Goals");
            Console.WriteLine("  4. Load Goals");
            Console.WriteLine("  5. Record Event");
            Console.WriteLine("  6. Quit");
            Console.Write("\nSelect a choice from the menu: ");

            choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    CreateGoal();
                    break;

                case 2:
                    ListGoalDetails();
                    break;

                case 3:
                    SaveGoals();
                    break;

                case 4:
                    LoadGoals();
                    break;

                case 5:
                    RecordEvent();
                    break;
            }
        }
    }

    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"Current Score: {_score} points");
        Console.WriteLine($"Current Level: {GetLevel()}");
    }

    private string GetLevel()
    {
        if (_score >= 5000)
            return "Goal Master";

        if (_score >= 3000)
            return "Champion";

        if (_score >= 1500)
            return "Explorer";

        if (_score >= 500)
            return "Beginner";

        return "Novice";
    }

    public void ListGoalDetails()
    {
        Console.WriteLine();

        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals have been created.");
            Console.ReadLine();
            return;
        }

        Console.WriteLine("Your Goals:");

        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }

        Console.WriteLine();
        Console.Write("Press Enter to continue...");
        Console.ReadLine();
    }

    public void CreateGoal()
    {
        Console.Clear();

        Console.WriteLine("Goal Types");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");

        Console.Write("Which type of goal would you like to create? ");
        int type = int.Parse(Console.ReadLine());

        Console.Write("Name: ");
        string name = Console.ReadLine();

        Console.Write("Description: ");
        string description = Console.ReadLine();

        Console.Write("Points: ");
        int points = int.Parse(Console.ReadLine());

        if (type == 1)
        {
            _goals.Add(new SimpleGoal(name, description, points));
        }
        else if (type == 2)
        {
            _goals.Add(new EternalGoal(name, description, points));
        }
        else if (type == 3)
        {
            Console.Write("How many times does this goal need to be completed? ");
            int target = int.Parse(Console.ReadLine());

            Console.Write("Bonus points upon completion: ");
            int bonus = int.Parse(Console.ReadLine());

            _goals.Add(new ChecklistGoal(name, description, points, target, bonus));
        }

        Console.WriteLine("\nGoal created successfully!");
        Console.ReadLine();
    }

    public void RecordEvent()
    {
        Console.Clear();

        if (_goals.Count == 0)
        {
            Console.WriteLine("There are no goals to record.");
            Console.ReadLine();
            return;
        }

        Console.WriteLine("Select the goal you completed:");

        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetShortName()}");
        }

        Console.Write("\nChoice: ");
        int choice = int.Parse(Console.ReadLine());

        int earned = _goals[choice - 1].RecordEvent();

        _score += earned;

        Console.WriteLine($"\nCongratulations! You earned {earned} points.");
        Console.WriteLine($"Total Score: {_score}");

        Console.ReadLine();
    }

    public void SaveGoals()
    {
        Console.Clear();

        Console.Write("Enter filename: ");
        string filename = Console.ReadLine();

        using (StreamWriter output = new StreamWriter(filename))
        {
            output.WriteLine(_score);

            foreach (Goal goal in _goals)
            {
                output.WriteLine(goal.GetStringRepresentation());
            }
        }

        Console.WriteLine("Goals saved successfully.");
        Console.ReadLine();
    }

    public void LoadGoals()
    {
        Console.Clear();

        Console.Write("Enter filename: ");
        string filename = Console.ReadLine();

        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found.");
            Console.ReadLine();
            return;
        }

        string[] lines = File.ReadAllLines(filename);

        _goals.Clear();

        _score = int.Parse(lines[0]);

        for (int i = 1; i < lines.Length; i++)
        {
            string[] parts = lines[i].Split('|');

            string type = parts[0];

            if (type == "SimpleGoal")
            {
                _goals.Add(new SimpleGoal(
                    parts[1],
                    parts[2],
                    int.Parse(parts[3]),
                    bool.Parse(parts[4])));
            }
            else if (type == "EternalGoal")
            {
                _goals.Add(new EternalGoal(
                    parts[1],
                    parts[2],
                    int.Parse(parts[3])));
            }
            else if (type == "ChecklistGoal")
            {
                _goals.Add(new ChecklistGoal(
                    parts[1],
                    parts[2],
                    int.Parse(parts[3]),
                    int.Parse(parts[5]),
                    int.Parse(parts[4]),
                    int.Parse(parts[6])));
            }
        }

        Console.WriteLine("Goals loaded successfully.");
        Console.ReadLine();
    }
}