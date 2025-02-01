using System;
using System.Collections.Generic;
using System.IO;

namespace JournalApp
{
    // Class to represent a Journal
    public class Journal
    {
        private List<Entry> _entries;

        // Constructor to initialize the journal
        public Journal()
        {
            _entries = new List<Entry>();
        }

        // Method to add an entry to the journal
        public void AddEntry(string prompt, string response)
        {
            Entry newEntry = new Entry(prompt, response);
            _entries.Add(newEntry);
        }

        // Method to display all journal entries
        public void DisplayEntries()
        {
            foreach (var entry in _entries)
            {
                Console.WriteLine(entry.ToString());
            }
        }

        // Method to save the journal entries to a file
        public void SaveToFile(string filename)
        {
            using (StreamWriter writer = new StreamWriter(filename))
            {
                foreach (var entry in _entries)
                {
                    writer.WriteLine($"{entry.Date}|{entry.Prompt}|{entry.Response}");
                }
            }
        }

        // Method to load journal entries from a file
        public void LoadFromFile(string filename)
        {
            _entries.Clear();
            string[] lines = File.ReadAllLines(filename);
            foreach (var line in lines)
            {
                string[] parts = line.Split('|');
                if (parts.Length == 3)
                {
                    Entry entry = new Entry(parts[1], parts[2], parts[0]);
                    _entries.Add(entry);
                }
            }
        }
    }

    // Class to represent a Journal Entry
    public class Entry
    {
        public string Prompt { get; set; }
        public string Response { get; set; }
        public string Date { get; set; }

        // Constructor to initialize a new entry
        public Entry(string prompt, string response)
        {
            Prompt = prompt;
            Response = response;
            Date = DateTime.Now.ToShortDateString();
        }

        // Constructor to initialize from loaded data
        public Entry(string prompt, string response, string date)
        {
            Prompt = prompt;
            Response = response;
            Date = date;
        }

        // Override ToString() to display the entry in a readable format
        public override string ToString()
        {
            return $"{Date} - Prompt: {Prompt} - Response: {Response}";
        }
    }

    // Main program logic
    class Program
    {
        static void Main(string[] args)
        {
            Journal myJournal = new Journal();

            // Define a list of prompts
            List<string> prompts = new List<string>
            {
                "Who was the most interesting person I interacted with today?",
                "What was the best part of my day?",
                "How did I see the hand of the Lord in my life today?",
                "What was the strongest emotion I felt today?",
                "If I had one thing I could do over today, what would it be?"
            };

            bool running = true;
            while (running)
            {
                Console.Clear();
                Console.WriteLine("Welcome to your Journal Application!");
                Console.WriteLine("1. Write a new entry");
                Console.WriteLine("2. Display all entries");
                Console.WriteLine("3. Save journal to a file");
                Console.WriteLine("4. Load journal from a file");
                Console.WriteLine("5. Exit");

                Console.Write("Please select an option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        // Randomly choose a prompt
                        Random rand = new Random();
                        string prompt = prompts[rand.Next(prompts.Count)];

                        Console.WriteLine($"\n{prompt}");
                        Console.Write("Your response: ");
                        string response = Console.ReadLine();

                        // Add the new entry to the journal
                        myJournal.AddEntry(prompt, response);
                        break;

                    case "2":
                        // Display all journal entries
                        myJournal.DisplayEntries();
                        Console.WriteLine("\nPress any key to return...");
                        Console.ReadKey();
                        break;

                    case "3":
                        // Save the journal to a file
                        Console.Write("\nEnter filename to save the journal: ");
                        string saveFile = Console.ReadLine();
                        myJournal.SaveToFile(saveFile);
                        Console.WriteLine("Journal saved successfully.");
                        Console.WriteLine("\nPress any key to return...");
                        Console.ReadKey();
                        break;

                    case "4":
                        // Load the journal from a file
                        Console.Write("\nEnter filename to load the journal: ");
                        string loadFile = Console.ReadLine();
                        myJournal.LoadFromFile(loadFile);
                        Console.WriteLine("Journal loaded successfully.");
                        Console.WriteLine("\nPress any key to return...");
                        Console.ReadKey();
                        break;

                    case "5":
                        running = false;
                        break;

                    default:
                        Console.WriteLine("Invalid choice, please try again.");
                        break;
                }
            }
        }
    }
}