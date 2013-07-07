using System;
using System.Collections.Generic;
using System.Text;

class SubstituteForbidenWordWithAsteriscs
{
    static void Main()
    {
        string textStr = "Microsoft announced its next generation PHP compiler today. It is based on .NET Framework 4.0 and is implemented as a dynamic language in CLR.";

        List<string> forbiddenWordsList = new List<string>();
        forbiddenWordsList.Add("Microsoft");
        forbiddenWordsList.Add("PHP");
        forbiddenWordsList.Add("CLR");

        StringBuilder censoredSB = new StringBuilder();
        StringBuilder currentWord = new StringBuilder();

        char asteriskCH = '*';

        for (int index = 0; index < textStr.Length; index++)
        {
            char currentChar = textStr[index];
            bool isValidChar = char.IsLetterOrDigit(currentChar) || char.IsPunctuation(currentChar);

            if (isValidChar)
            {
                currentWord.Append(currentChar);
                continue;
            }

            censoredSB.Append(' ');

            if (HasMatch(currentWord, forbiddenWordsList))
            {
                censoredSB.Append(new string(asteriskCH, currentWord.Length));
            }
            else
            {
                censoredSB.Append(currentWord);
            }
            currentWord.Clear();
        }
        Console.WriteLine(censoredSB.ToString().Trim(' '));
    }

    private static bool HasMatch(StringBuilder word, List<string> words)
    {
        bool hasMatch = false;
        string wordStr = word.ToString().Trim('.');

        foreach (var item in words)
        {
            if (item.Equals(wordStr))
            {
                hasMatch = true;
                break;
            }
        }
        return hasMatch;
    }
}