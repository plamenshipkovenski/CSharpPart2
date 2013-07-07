using System;
using System.Collections.Generic;
using System.Text;

class CountWords
{

    private static void ProcessWord(List<string> wordsList, List<int> occurencesList, StringBuilder wordSB, int wordIndex)
    {
        if (WordExistIn(wordsList, wordSB, ref wordIndex))
        {
            occurencesList[wordIndex] += 1;
        }
        else
        {
            if (!string.IsNullOrEmpty(wordSB.ToString().Trim()))
            {
                wordsList.Add(wordSB.ToString());
                occurencesList.Add(1);
            }
        }
    }

    private static bool WordExistIn(List<string> wordsList, StringBuilder wordSB, ref int wordIndex)
    {
        bool hasFound = false;
        string word = wordSB.ToString();

        for (int i = 0; i < wordsList.Count; i++)
        {
            if (word.Equals(wordsList[i], StringComparison.OrdinalIgnoreCase))
            {
                wordIndex = i;
                hasFound = true;
                break;
            }
        }
        return hasFound;
    }

    static void Main()
    {
        Console.WriteLine("input string:");
        string inputStr = Console.ReadLine();

        List<string> wordsList = new List<string>();
        List<int> occurencesList = new List<int>();

        StringBuilder wordSB = new StringBuilder();
        int wordIndex = -1;

        for (int i = 0; i < inputStr.Length; i++)
        {
            char currentChar = inputStr[i];

            if (char.IsLetter(currentChar))
            {
                wordSB.Append(currentChar);

                if (i == inputStr.Length - 1)
                {
                    ProcessWord(wordsList, occurencesList, wordSB, wordIndex);
                }
            }
            else
            {
                ProcessWord(wordsList, occurencesList, wordSB, wordIndex);
                wordSB.Clear();
            }
        }

        for (int i = 0; i < wordsList.Count; i++)
        {
            Console.WriteLine("{0} --> {1} times", wordsList[i], occurencesList[i]);
        }
    }
}