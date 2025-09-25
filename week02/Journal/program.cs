using System;
using System.Collections.Generic;
using System.Text;

// --- EXCEEDING REQUIREMENTS: JSON IMPLEMENTATION ---
// To exceed the requirements and improve data integrity, this program utilizes 
// the System.Text.Json library to save and load the journal entries. 
// This is a robust approach that correctly handles complex user input 
// (like multiline text and special characters) by serializing the entire 
// List<Entry> object into a structured JSON format, replacing the less reliable 
// custom delimited file format.
// ----------------------------------------------------

public class Program
{
    private Journal _journal = new Journal();
    private PromptGenerator _promptGenerator = new PromptGenerator();

    public static void Main(string[] args)
    {
        Program app = new Program();
        app.Run();
    }

    public void Run()
    {
        Console.WriteLine(" Welcome to the Simple Daily Journal App!");
        while (true)
        {
            DisplayMenu();
            string choice = Console.ReadLine();
            
            switch (choice)
            {
                case "1":
                    WriteNewEntry();
                    break;
                case "2":
                    _journal.DisplayJournal();
                    break;
                case "3":
                    SaveJournal();
                    break;
                case "4":
                    LoadJournal();
                    break;
                case "5":
                    Console.WriteLine("\n Thank you for journaling! Goodbye.");
                    return;
                default:
                    Console.WriteLine("\n Invalid choice. Please select a number from 1 to 5.");
                    break;
            }
            Console.Write("\nPress Enter to return to the menu...");
            Console.ReadLine(); // Pause before re-displaying the menu
        }
    }

    private void DisplayMenu()
    {
        Console.WriteLine("\n" + new string('-', 30));
        Console.WriteLine("     Journal Menu");
        Console.WriteLine(new string('-', 30));
        Console.WriteLine("1. Write a new entry");
        Console.WriteLine("2. Display the journal");
        Console.WriteLine("3. Save the journal to a file (JSON)"); // Menu updated to reflect JSON
        Console.WriteLine("4. Load the journal from a file (JSON)"); // Menu updated to reflect JSON
        Console.WriteLine("5. Quit");
        Console.Write("What would you like to do? (1-5): ");
    }

    private void WriteNewEntry()
    {
        string prompt = _promptGenerator.GetRandomPrompt();
        
        Console.WriteLine("\n" + new string('=', 40));
        Console.WriteLine("        New Journal Entry");
        Console.WriteLine(new string('=', 40));
        Console.WriteLine($"**PROMPT:** {prompt}");
        Console.WriteLine(new string('-', 40));
        Console.WriteLine("Your response (Type 'END' on a new line to finish):");

        // Collect multiline input
        StringBuilder responseBuilder = new StringBuilder();
        string line;
        while ((line = Console.ReadLine()) != null && line.ToUpper() != "END")
        {
            responseBuilder.AppendLine(line);
        }

        string response = responseBuilder.ToString().Trim();
        
        if (!string.IsNullOrEmpty(response))
        {
            Entry newEntry = new Entry(prompt, response);
            _journal.AddEntry(newEntry);
            Console.WriteLine("\n👍 Entry successfully recorded!");
        }
        else
        {
            Console.WriteLine("\n Entry cancelled: Response was empty.");
        }
    }

    private void SaveJournal()
    {
        // Suggesting a JSON file extension
        Console.Write("Enter the filename to save to (e.g., my_journal.json): ");
        string filename = Console.ReadLine().Trim();
        if (!string.IsNullOrEmpty(filename))
        {
            _journal.SaveToFile(filename);
        }
        else
        {
            Console.WriteLine("\n Save cancelled: Filename cannot be empty.");
        }
    }

    private void LoadJournal()
    {
        // Suggesting a JSON file extension
        Console.Write("Enter the filename to load from (e.g., my_journal.json): ");
        string filename = Console.ReadLine().Trim();
        if (!string.IsNullOrEmpty(filename))
        {
            _journal.LoadFromFile(filename);
        }
        else
        {
            Console.WriteLine("\n Load cancelled: Filename cannot be empty.");
        }
    }
}