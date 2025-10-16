public class Program
{
    public static void Main(string[] args)
    {
        // Create at least one activity of each type
        Running run1 = new Running("18 Oct 2025", 30, 4.8);     // 4.8 km in 30 min
        Cycling cycle1 = new Cycling("19 Oct 2025", 45, 25.0); // 25.0 kph for 45 min
        Swimming swim1 = new Swimming("20 Oct 2025", 60, 40);   // 40 laps (2 km) in 60 min

        // Create a list of the base type (Activity)
        List<Activity> activities = new List<Activity>
        {
            run1,
            cycle1,
            swim1
        };

        Console.WriteLine("--- Fitness Activity Summary ---");
        Console.WriteLine("Units: Kilometers (km) and Kilometers per Hour (kph)\n");

        // Iterate through the list and call the polymorphic GetSummary method
        foreach (Activity activity in activities)
        {
            // Polymorphism: The base class method is called, but it internally
            // calls the specialized, overridden GetDistance, GetSpeed, and GetPace methods.
            string summary = activity.GetSummary();
            Console.WriteLine(summary);
        }
        
        Console.WriteLine("\n------------------------------");
    }
}
