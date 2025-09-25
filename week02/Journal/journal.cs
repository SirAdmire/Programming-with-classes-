using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json; // NEW: Added for JSON serialization

public class Journal
{
    private List<Entry> _entries;

    public Journal()
    {
        _entries = new List<Entry>();
    }

    // Existing methods (AddEntry, DisplayJournal) are the same

    public void AddEntry(Entry entry)
    {
        _entries.Add(entry);
    }

    public void DisplayJournal()
    {
        if (!_entries.Any())
        {
            Console.WriteLine("\n Your journal is empty. Write an entry first!");
            return;
        }

        Console.WriteLine("\n" + new string('=', 50));
        Console.WriteLine("           Your Complete Journal (JSON Format) ");
        Console.WriteLine(new string('=', 50));
        
        // Display entries in reverse order (most recent first)
        foreach (var entry in _entries.AsEnumerable().Reverse())
        {
            Console.WriteLine("--- Entry ---");
            Console.WriteLine(entry);
        }
        
        Console.WriteLine(new string('=', 50));
    }

    /// <summary>
    /// Saves the current journal entries to a specified file using JSON format.
    /// </summary>
    public void SaveToFile(string filename)
    {
        try
        {
            // Serialize the entire List<Entry> object into a JSON string
            string jsonString = JsonSerializer.Serialize(_entries, new JsonSerializerOptions { WriteIndented = true });
            
            // Write the JSON string to the file
            File.WriteAllText(filename, jsonString);
            Console.WriteLine($"\n Journal successfully saved as JSON to {filename}");
        }
        catch (IOException ex)
        {
            Console.WriteLine($"\n Error saving file: {ex.Message}");
        }
        catch (JsonException ex)
        {
             Console.WriteLine($"\n Error serializing data: {ex.Message}");
        }
    }

    /// <summary>
    /// Loads entries from a specified JSON file, replacing the current journal.
    /// </summary>
    public void LoadFromFile(string filename)
    {
        if (!File.Exists(filename))
        {
            Console.WriteLine($"\n Error: File '{filename}' not found.");
            return;
        }

        try
        {
            // Read the entire JSON string from the file
            string jsonString = File.ReadAllText(filename);
            
            // Deserialize the JSON string back into a List<Entry>
            List<Entry> loadedEntries = JsonSerializer.Deserialize<List<Entry>>(jsonString);
            
            if (loadedEntries != null)
            {
                _entries = loadedEntries;
                Console.WriteLine($"\n Journal successfully loaded from {filename}. Total entries: {_entries.Count}");
            }
            else
            {
                Console.WriteLine("\n Warning: Loaded file was empty or corrupted. Journal remains unchanged.");
            }
        }
        catch (IOException ex)
        {
            Console.WriteLine($"\n Error loading file: {ex.Message}");
        }
        catch (JsonException ex)
        {
             Console.WriteLine($"\n Error deserializing data. File may be corrupted: {ex.Message}");
        }
    }
}