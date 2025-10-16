using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

// Note: In a real C# project, you would ensure the other file's classes are
// accessible either by being in the same project/namespace or by being explicitly included.

public class Program
{
    public static void Main(string[] args)
    {
        // Manager class is instantiated to hold the state and run the program logic
        GoalManager manager = new GoalManager();
        string filename = "goals_data.txt";
        manager.LoadGoals(filename); // Try to load data on startup

        bool running = true;
        while (running)
        {
            manager.DisplayPlayerInfo();
            Console.WriteLine("\nMenu Options:");
            Console.WriteLine("  1. Create New Goal");
            Console.WriteLine("  2. List Goals");
            Console.WriteLine("  3. Record Event");
            Console.WriteLine("  4. Save Goals");
            Console.WriteLine("  5. Load Goals");
            Console.WriteLine("  6. Quit");
            Console.Write("Select a choice from the menu: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    manager.CreateGoal();
                    break;
                case "2":
                    manager.ListGoalDetails();
                    break;
                case "3":
                    manager.RecordEvent();
                    break;
                case "4":
                    manager.SaveGoals(filename);
                    break;
                case "5":
                    manager.LoadGoals(filename);
                    break;
                case "6":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }

        Console.WriteLine("Thank you for using the Eternal Quest program. Goodbye!");
    }
}
