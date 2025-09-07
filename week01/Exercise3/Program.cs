using System;

public class Program
{
    public static void Main(string[] args)
    {
        // Outer loop to allow the user to play again
        string playAgain = "yes";
        while (playAgain.ToLower() == "yes")
        {
            
            Random random = new Random();
            int magicNumber = random.Next(1, 101); 

            
            int guessCount = 0;
            int guess = -1; 

            while (guess != magicNumber)
            {
                Console.Write("What is your guess? ");
                string guessInput = Console.ReadLine();
                guess = int.Parse(guessInput);

                guessCount++;

                if (guess < magicNumber)
                {
                    Console.WriteLine("Higher");
                }
                else if (guess > magicNumber)
                {
                    Console.WriteLine("Lower");
                }
                else
                {
                    Console.WriteLine("You guessed it!");
                }
            }
            
            Console.WriteLine($"It took you {guessCount} guesses.");
            
            Console.Write("Do you want to play again? (yes/no) ");
            playAgain = Console.ReadLine();
        }
    }
}
