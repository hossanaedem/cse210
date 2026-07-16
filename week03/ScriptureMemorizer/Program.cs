using System;


/*
Creativity:
This program exceeds the basic requirements by:
1. Preventing already hidden words from being selected again.
2. Selecting the number of words to hide randomly each round.
This creates a better scripture memorization experience.
*/


class Program
{
    static void Main(string[] args)
    {

        Reference reference = new Reference(
            "Isaiah",
            41,
            10
        );


        Scripture scripture = new Scripture(
            reference,
            "Fear thou not for I am with thee be not dismayed for I am thy God I will strengthen thee yea I will help thee yea I will uphold thee with the right hand of my righteousness"
        );


        while (!scripture.IsCompletelyHidden())
        {

            // Console.Clear();

            Console.WriteLine(scripture.GetDisplayText());


            // Console.WriteLine();

            Console.WriteLine("Press Enter to hide words or type quit to exit:");

            string input = Console.ReadLine();


            if (string.Equals(input, "quit", StringComparison.OrdinalIgnoreCase))
            {
                break;
            }


            Random random = new Random();

            int wordsToHide = random.Next(2, 5);


            scripture.HideRandomWords(wordsToHide);

        }


        // Console.Clear();

        Console.WriteLine(scripture.GetDisplayText());

        Console.WriteLine();

        Console.WriteLine("Scripture memorization complete!");
    }
}