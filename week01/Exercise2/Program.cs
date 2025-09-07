using System;

public class Program
{
    public static void Main(string[] args)
    {
        Console.Write("Please enter your grade percentage: ");
        string gradeInput = Console.ReadLine();
        
        int gradePercentage = int.Parse(gradeInput);

        string letter = "";
        string sign = "";

        if (gradePercentage >= 90)
        {
            letter = "A";
        }
        else if (gradePercentage >= 80)
        {
            letter = "B";
        }
        else if (gradePercentage >= 70)
        {
            letter = "C";
        }
        else if (gradePercentage >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }
        
        int lastDigit = gradePercentage % 10;
        
        if (lastDigit >= 7)
        {
            sign = "+";
        }
        else if (lastDigit < 3)
        {
            sign = "-";
        }
        else
        {
            sign = "";
        }
        
        if (gradePercentage >= 93)
        {
            sign = "";
        }

        if (letter == "F")
        {
            sign = "";
        }
        Console.WriteLine($"Your letter grade is: {letter}{sign}");

        if (gradePercentage >= 70)
        {
            Console.WriteLine("Congratulations! You passed the course.");
        }
        else
        {
            Console.WriteLine("Don't worry, you can do better next time!");
        }
    }
}
