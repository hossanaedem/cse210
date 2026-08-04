using System;

public abstract class Goal
{
    // Shared member variables
    private string _shortName;
    private string _description;
    private int _points;

    // Constructor
    public Goal(string shortName, string description, int points)
    {
        _shortName = shortName;
        _description = description;
        _points = points;
    }

    // Getters
    public string GetShortName()
    {
        return _shortName;
    }

    public string GetDescription()
    {
        return _description;
    }

    public int GetPoints()
    {
        return _points;
    }

    // Returns the goal details for display
    public virtual string GetDetailsString()
    {
        string checkBox = IsComplete() ? "[X]" : "[ ]";
        return $"{checkBox} {_shortName} ({_description})";
    }

    // Methods that each derived class must implement
    public abstract int RecordEvent();

    public abstract bool IsComplete();

    public abstract string GetStringRepresentation();
}