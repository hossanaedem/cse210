using System;

public class SimpleGoal : Goal
{
    // Member variable specific to SimpleGoal
    private bool _isComplete;

    // Constructor for creating a new Simple Goal
    public SimpleGoal(string shortName, string description, int points)
        : base(shortName, description, points)
    {
        _isComplete = false;
    }

    // Constructor for loading a saved Simple Goal
    public SimpleGoal(string shortName, string description, int points, bool isComplete)
        : base(shortName, description, points)
    {
        _isComplete = isComplete;
    }

    // Records the event and awards points only once
    public override int RecordEvent()
    {
        if (!_isComplete)
        {
            _isComplete = true;
            return GetPoints();
        }

        Console.WriteLine("This goal has already been completed.");
        return 0;
    }

    // Returns whether the goal has been completed
    public override bool IsComplete()
    {
        return _isComplete;
    }

    // Returns a string for saving the goal to a file
    public override string GetStringRepresentation()
    {
        return $"SimpleGoal|{GetShortName()}|{GetDescription()}|{GetPoints()}|{_isComplete}";
    }
}