using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        // Video 1
        Video video1 = new Video(
            "Learning C# Basics",
            "Hossana D Coder",
            600);

        video1.AddComment(new Comment("Williams-Effiom", "Crystal clear, thanks!"));
        video1.AddComment(new Comment("Grace-Okon", "Perfecte explanation of C#."));
        video1.AddComment(new Comment("Bassey-Thomas", "Super helpful guide!"));

        videos.Add(video1);


        // Video 2
        Video video2 = new Video(
            "Object Oriented Programming",
            "Programming Academy",
            900);

        video2.AddComment(new Comment("Charles-Egbo", "OOP is easier now."));
        video2.AddComment(new Comment("Wisdom-Essien", "Nice examples."));
        video2.AddComment(new Comment("Henry Addey-Williams", "Thanks for sharing."));

        videos.Add(video2);


        // Video 3
        Video video3 = new Video(
            "Introduction to Classes",
            "Code World",
            720);

        video3.AddComment(new Comment("Happiness-Ibiang", "Classes make coding organized."));
        video3.AddComment(new Comment("Ndiyo-Ekpeyong", "Great teaching style."));
        video3.AddComment(new Comment("Favour-Ekpe", "I learned something new."));

        videos.Add(video3);


        // Display videos
        foreach (Video video in videos)
        {
            Console.WriteLine("----------------------------");
            Console.WriteLine($"Title: {video.GetTitle()}");
            Console.WriteLine($"Author: {video.GetAuthor()}");
            Console.WriteLine($"Length: {video.GetLength()} seconds");
            Console.WriteLine($"Comments: {video.GetNumberOfComments()}");

            Console.WriteLine("\nComments:");

            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine(
                    $"- {comment.GetName()}: {comment.GetText()}");
            }

            Console.WriteLine();
        }
    }
}