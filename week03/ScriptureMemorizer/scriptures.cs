using System;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Models a scripture reference (e.g., "John 3:16" or "Proverbs 3:5-6").
/// </summary>
public class Reference
{
    // Changed access to internal for easier deep copying in Program.GetRandomScripture()
    internal string _book;
    internal int _chapter;
    internal int _startVerse;
    internal int? _endVerse; 

    /// <summary>
    /// Constructor for a single-verse scripture reference.
    /// </summary>
    public Reference(string book, int chapter, int verse)
    {
        _book = book;
        _chapter = chapter;
        _startVerse = verse;
        _endVerse = null;
    }

    /// <summary>
    /// Constructor for a scripture reference with a verse range.
    /// </summary>
    public Reference(string book, int chapter, int startVerse, int endVerse)
    {
        _book = book;
        _chapter = chapter;
        _startVerse = startVerse;
        _endVerse = endVerse;
    }

    /// <summary>
    /// Returns the formatted display text of the scripture reference.
    /// </summary>
    public string GetDisplayText()
    {
        if (_endVerse.HasValue)
        {
            return $"{_book} {_chapter}:{_startVerse}-{_endVerse}";
        }
        else
        {
            return $"{_book} {_chapter}:{_startVerse}";
        }
    }
}

/// <summary>
/// Represents a single word in the scripture text.
/// </summary>
public class Word
{
    private string _text;
    private bool _isHidden;

    public Word(string text)
    {
        _text = text;
        _isHidden = false;
    }

    /// <summary>
    /// Hides the word by setting its internal state.
    /// </summary>
    public void Hide()
    {
        _isHidden = true;
    }

    /// <summary>
    /// Returns whether the word is currently hidden.
    /// </summary>
    public bool IsHidden()
    {
        return _isHidden;
    }

    /// <summary>
    /// Returns the text to be displayed. If hidden, returns underscores.
    /// </summary>
    public string GetDisplayText()
    {
        if (_isHidden)
        {
            return new string('_', _text.Length);
        }
        else
        {
            return _text;
        }
    }

    /// <summary>
    /// Returns the original, unhidden text (used for deep copying).
    /// </summary>
    public string GetOriginalText()
    {
        return _text;
    }
}

/// <summary>
/// Encapsulates the entire scripture, managing its reference and list of words.
/// </summary>
public class Scripture
{
    internal Reference _reference;
    internal List<Word> _words;
    private Random _random = new Random();

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        // Split the text into a list of Word objects
        string[] wordArray = text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        _words = new List<Word>();
        foreach (string word in wordArray)
        {
            _words.Add(new Word(word));
        }
    }

    /// <summary>
    /// Hides a specified number of unhidden words in the scripture.
    /// (Creative Enhancement: Only selects words that are not already hidden.)
    /// </summary>
    public void HideWords(int numberToHide)
    {
        var unhiddenWords = _words.Where(w => !w.IsHidden()).ToList();
        
        // Prevent trying to hide more words than are available
        int actualNumberToHide = Math.Min(numberToHide, unhiddenWords.Count);
        
        for (int i = 0; i < actualNumberToHide; i++)
        {
            int index = _random.Next(0, unhiddenWords.Count);
            unhiddenWords[index].Hide();
            unhiddenWords.RemoveAt(index); // Remove from temp list to prevent re-selection
        }
    }

    /// <summary>
    /// Returns the formatted display text of the entire scripture.
    /// </summary>
    public string GetDisplayText()
    {
        var referenceText = _reference.GetDisplayText();
        var scriptureText = string.Join(" ", _words.Select(w => w.GetDisplayText()));
        return $"{referenceText} {scriptureText}";
    }

    /// <summary>
    /// Checks if all words in the scripture are hidden.
    /// </summary>
    public bool IsCompletelyHidden()
    {
        return _words.All(w => w.IsHidden());
    }
}