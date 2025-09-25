using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;


// --- EXCEEDING REQUIREMENTS: CREATIVE ENHANCEMENTS ---
// This program goes beyond the core requirements by including the following features:
// 1. A Library of Scriptures: Instead of a single scripture, the program maintains a
//    library of several scriptures, from which it selects one at random for each
//    memorization session.
// 2. Intelligent Word Hiding: The 'Scripture.HideWords()' method is designed to
//    intelligently select and hide only words that are not already hidden. This
//    provides a more effective and logical memorization flow.
// 3. Continuous Practice: When a scripture is fully hidden, the program offers the
//    user the option to start a new session with a new, random scripture, promoting
//    extended practice without needing to restart the application.
// ----------------------------------------------------

public class Program
{
    private static List<Scripture> _scriptureLibrary;

    private static void InitializeScriptureLibrary()
    {
        // Populate the library with various scriptures
        _scriptureLibrary = new List<Scripture>
        {
            // Note: The Reference and Scripture classes must be accessible for this code to compile.
            new Scripture(new Reference("John", 3, 16), "For God so loved the world, that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life."),
            new Scripture(new Reference("Proverbs", 3, 5, 6), "Trust in the Lord with all thine heart; and lean not unto thine own understanding. In all thy ways acknowledge him, and he shall direct thy paths."),
            new Scripture(new Reference("Mosiah", 2, 41), "And moreover, I would desire that ye should consider on the blessed and happy state of those that keep the commandments of God. For behold, they are blessed in all things, both temporal and spiritual; and if they hold out faithful to the end they are received into heaven, that thereby they may dwell with God in a state of never-ending happiness. O, remember, remember that these things are true; for the Lord God hath spoken it."),
            new Scripture(new Reference("Ether", 12, 27), "And if men come unto me I will show unto them their weakness. I give unto men weakness that they may be humble; and my grace is sufficient for all men that humble themselves before me; for if they humble themselves before me, and have faith in me, then will I make weak things become strong unto them."),
        };
    }

    private static Scripture GetRandomScripture()
    {
        Random random = new Random();
        int index = random.Next(0, _scriptureLibrary.Count);
        
        // This is necessary to create a deep copy of the Scripture object 
        // to ensure that hiding words in one session doesn't hide them in the library object.
        var original = _scriptureLibrary[index];
        var text = string.Join(" ", original._words.Select(w => w.GetOriginalText()));

        // The logic for reconstructing the reference from the original object.
        Reference newReference;
        if (original._reference._endVerse.HasValue)
        {
            newReference = new Reference(original._reference._book, original._reference._chapter, original._reference._startVerse, original._reference._endVerse.Value);
        }
        else
        {
            newReference = new Reference(original._reference._book, original._reference._chapter, original._reference._startVerse);
        }

        return new Scripture(newReference, text);
    }


    public static void Main(string[] args)
    {
        InitializeScriptureLibrary();
        
        while (true)
        {
            Scripture currentScripture = GetRandomScripture();
            
            while (!currentScripture.IsCompletelyHidden())
            {
                Console.Clear();
                Console.WriteLine(currentScripture.GetDisplayText());
                Console.WriteLine("\nPress Enter to hide more words or type 'quit' to exit.");
                string input = Console.ReadLine();
                
                if (input != null && input.ToLower() == "quit")
                {
                    return; // End the program
                }
                
                // Hide a few words on each turn (a random number between 3 and 5)
                Random random = new Random();
                currentScripture.HideWords(random.Next(3, 6));
            }

            // After the scripture is completely hidden
            Console.Clear();
            Console.WriteLine(currentScripture.GetDisplayText());
            Console.WriteLine("\n🎉 Congratulations! You have hidden all the words in this scripture.");
            Console.WriteLine("Press Enter to practice a new scripture or type 'quit' to exit.");
            string finalInput = Console.ReadLine();
            
            if (finalInput != null && finalInput.ToLower() == "quit")
            {
                return; // End the program
            }
        }
    }
}