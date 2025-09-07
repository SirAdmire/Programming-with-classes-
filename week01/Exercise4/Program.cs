using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main(string[] args)
    {
        List<int> numbers = new List<int>();

        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        int number;
        do
        {
            Console.Write("Enter number: ");
            string userInput = Console.ReadLine();
            number = int.Parse(userInput);

            if (number != 0)
            {
                numbers.Add(number);
            }

        } while (number != 0);

        int sum = 0;
        foreach (int item in numbers)
        {
            sum += item;
        }
        Console.WriteLine($"The sum is: {sum}");

        double average = 0;
        if (numbers.Count > 0)
        {
            average = (double)sum / numbers.Count;
        }
        Console.WriteLine($"The average is: {average}");

        int max = 0;
        if (numbers.Count > 0)
        {
            max = numbers.Max();
        }
        Console.WriteLine($"The largest number is: {max}");
        
        int smallestPositive = int.MaxValue;
        foreach (int item in numbers)
        {
            if (item > 0 && item < smallestPositive)
            {
                smallestPositive = item;
            }
        }
        if (smallestPositive != int.MaxValue)
        {
            Console.WriteLine($"The smallest positive number is: {smallestPositive}");
        }

        numbers.Sort();
        Console.WriteLine("The sorted list is:");
        foreach (int item in numbers)
        {
            Console.WriteLine(item);
        }
    }
}
