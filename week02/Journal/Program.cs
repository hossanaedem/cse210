using System;

/*
Creativity:
I added a Mood field to every journal entry.
The user can record how they felt during the day.
This information is saved and loaded with every journal entry.
*/

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();

        int choice = 0;

        while (choice != 5)
        {
            Console.WriteLine();
            Console.WriteLine("Journal Program");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Quit");
            Console.Write("What would you like to do? ");

            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Please enter a number.");
                continue;
            }

            switch (choice)
            {
                case 1:

                    Entry entry = new Entry();

                    entry._date = DateTime.Now.ToShortDateString();

                    entry._promptText = promptGenerator.GetRandomPrompt();

                    Console.WriteLine();
                    Console.WriteLine(entry._promptText);

                    Console.Write("> ");
                    entry._entryText = Console.ReadLine();

                    Console.Write("Mood today: ");
                    entry._mood = Console.ReadLine();

                    journal.AddEntry(entry);

                    break;

                case 2:

                    journal.DisplayAll();

                    break;

                case 3:

                    Console.Write("Filename: ");
                    string loadFile = Console.ReadLine();

                    journal.LoadFromFile(loadFile);

                    break;

                case 4:

                    Console.Write("Filename: ");
                    string saveFile = Console.ReadLine();

                    journal.SaveToFile(saveFile);

                    break;

                case 5:

                    Console.WriteLine("Goodbye!");

                    break;

                default:

                    Console.WriteLine("Invalid choice.");

                    break;
            }
        }
    }
}