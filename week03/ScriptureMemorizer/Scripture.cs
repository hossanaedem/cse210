using System;
using System.Collections.Generic;

public class Scripture
{
    // Private member variables (Encapsulation)
    private Reference _reference;
    private List<Word> _words;
    private Random _random;

    // Constructor
    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();
        _random = new Random();

        string[] wordArray = text.Split(' ');

        foreach (string wordText in wordArray)
        {
            _words.Add(new Word(wordText));
        }
    }

    // Returns the scripture with hidden words replaced by underscores
    public string GetDisplayText()
    {
        List<string> displayedWords = new List<string>();

        foreach (Word word in _words)
        {
            displayedWords.Add(word.GetDisplayText());
        }

        return $"{_reference.GetDisplayText()} {string.Join(" ", displayedWords)}";
    }

    // Hides a specified number of random visible words
    public void HideRandomWords(int numberOfWords)
    {
        List<Word> visibleWords = new List<Word>();

        foreach (Word word in _words)
        {
            if (!word.IsHidden())
            {
                visibleWords.Add(word);
            }
        }

        // Stop if there are no visible words left
        if (visibleWords.Count == 0)
        {
            return;
        }

        int wordsToHide = Math.Min(numberOfWords, visibleWords.Count);

        for (int i = 0; i < wordsToHide; i++)
        {
            int randomIndex = _random.Next(visibleWords.Count);

            visibleWords[randomIndex].Hide();

            // Remove the word so it can't be selected again this round
            visibleWords.RemoveAt(randomIndex);
        }
    }

    // Checks if every word has been hidden
    public bool IsCompletelyHidden()
    {
        foreach (Word word in _words)
        {
            if (!word.IsHidden())
            {
                return false;
            }
        }

        return true;
    }
}