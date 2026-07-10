using System;

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job("TechCorp", "Software Engineer", "2020", "2023");
        job1.DisplayJob();
        
        Job job2 = new Job("Innovate Solutions", "Project Manager", "2018", "2020");
        job2.DisplayJob();

        Resume resume = new Resume("Hossana Edem");
        resume.AddJob(job1);

        resume.AddJob(job2); // Use the AddJob method to add jobs to the resume
        resume.DisplayResume();

        
        Console.WriteLine("Hello World! This is the Resumes Project.");
    }
}