using System;
using System.Collections.Generic;

class CountLetters
{

    private static bool CharExistIn(List<char> lettersList, char currentChar, ref int letterIndex)
    {
        bool hasFound = false;

        for (int i = 0; i < lettersList.Count; i++)
        {
            if (currentChar == lettersList[i])
            {
                letterIndex = i;
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

        List<char> lettersList = new List<char>();
        List<int> occurencesList = new List<int>();
        int letterIndex = -1;

        for (int i = 0; i < inputStr.Length; i++)
        {
            char currentChar = inputStr[i];

            if (char.IsLetter(currentChar))
            {
                if (CharExistIn(lettersList, currentChar, ref letterIndex))
                {
                    occurencesList[letterIndex]++;
                }
                else
                {
                    lettersList.Add(currentChar);
                    occurencesList.Add(1);
                }
            }
        }

        for (int i = 0; i < lettersList.Count; i++)
        {
            Console.WriteLine("{0} --> {1}", lettersList[i], occurencesList[i]);
        }
    }
}