using System;

public class Job
{
    private string _company;
    private string _jobTitle;
    private string _startYear;
    private string _endYear;

    public Job(string company, string jobTitle, string startYear, string endYear)
    {
        _company = company;
        _jobTitle = jobTitle;
        _startYear = startYear;
        _endYear = endYear;
    }

    public void DisplayJob()
    {
        Console.WriteLine($"{_jobTitle} at {_company} ({_startYear} - {_endYear})");
    }
}