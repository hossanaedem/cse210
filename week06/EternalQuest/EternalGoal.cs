using System;

public class EternalGoal : Goal
{
    // Constructor for creating a new Eternal Goal
    public EternalGoal(string shortName, string description, int points)
        : base(shortName, description, points)
    {
    }

    // Records the event and always awards points
    public override int RecordEvent()
    {
        return GetPoints();
    }

    // Eternal goals are never complete
    public override bool IsComplete()
    {
        return false;
    }

    // Returns a string for saving the goal to a file
    public override string GetStringRepresentation()
    {
        return $"EternalGoal|{GetShortName()}|{GetDescription()}|{GetPoints()}";
    }
}