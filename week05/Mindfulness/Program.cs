using System;

// Exceeding Requirements:
// 1. Added a robust 'Start' method in the Base class to manage the three stages: start, run, end.
// 2. Added clear line clearing (\r and \b) in the Breathing Activity to make the countdown/messages less cluttered and more polished.
// 3. Implemented a basic check for non-blocking input in the Listing Activity to allow the loop to terminate when the duration is met, instead of hanging indefinitely on Console.ReadLine().

class Program
{
    static void Main(string[] args)
    {
        string choice = "";

        while (choice != "4")
        {
            Console.Clear();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Start breathing activity");
            Console.WriteLine("  2. Start reflecting activity");
            Console.WriteLine("  3. Start listing activity");
            Console.WriteLine("  4. Quit");
            Console.Write("Select a choice from the menu: ");

            choice = Console.ReadLine();

            Activity activity = null;

            switch (choice)
            {
                case "1":
                    activity = new BreathingActivity();
                    break;
                case "2":
                    activity = new ReflectionActivity();
                    break;
                case "3":
                    activity = new ListingActivity();
                    break;
                case "4":
                    Console.WriteLine("Thank you for using the Mindfulness Program. Goodbye!");
                    return; // Exit the Main method
                default:
                    Console.WriteLine("Invalid choice. Press Enter to return to the menu.");
                    Console.ReadLine();
                    continue; // Skip the rest of the loop and show the menu again
            }

            // Run the selected activity
            if (activity != null)
            {
                activity.Start();
            }
        }
    }
}
