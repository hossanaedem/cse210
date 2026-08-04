using System;

public class ChecklistGoal : Goal
{
    // Member variables specific to ChecklistGoal
    private int _amountCompleted;
    private int _targetAmount;
    private int _bonus;

    // Constructor for creating a new Checklist Goal
    public ChecklistGoal(string shortName, string description, int points, int targetAmount, int bonus)
        : base(shortName, description, points)
    {
        _amountCompleted = 0;
        _targetAmount = targetAmount;
        _bonus = bonus;
    }

    // Constructor for loading a saved Checklist Goal
    public ChecklistGoal(string shortName, string description, int points,
                         int targetAmount, int bonus, int amountCompleted)
        : base(shortName, description, points)
    {
        _targetAmount = targetAmount;
        _bonus = bonus;
        _amountCompleted = amountCompleted;
    }

    // Records progress toward completing the goal
    public override int RecordEvent()
    {
        if (_amountCompleted < _targetAmount)
        {
            _amountCompleted++;

            if (_amountCompleted == _targetAmount)
            {
                Console.WriteLine("Congratulations! You completed the checklist goal!");
                Console.WriteLine($"You earned a bonus of {_bonus} points!");
                return GetPoints() + _bonus;
            }

            return GetPoints();
        }

        Console.WriteLine("This checklist goal has already been completed.");
        return 0;
    }

    // Returns true if the checklist goal is complete
    public override bool IsComplete()
    {
        return _amountCompleted >= _targetAmount;
    }

    // Displays the goal with its progress
    public override string GetDetailsString()
    {
        string checkBox = IsComplete() ? "[X]" : "[ ]";

        return $"{checkBox} {GetShortName()} ({GetDescription()}) -- Completed {_amountCompleted}/{_targetAmount} times";
    }

    // Returns a string for saving the goal to a file
    public override string GetStringRepresentation()
    {
        return $"ChecklistGoal|{GetShortName()}|{GetDescription()}|{GetPoints()}|{_bonus}|{_targetAmount}|{_amountCompleted}";
    }
}