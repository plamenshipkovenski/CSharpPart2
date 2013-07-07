using System;
using System.Collections.Generic;

class SampleDictionary
{
    static void Main()
    {
        Console.WriteLine("input word:");
        string word = Console.ReadLine();

        List<string> dictionaryList = new List<string>();
        dictionaryList.Add(".NET – platform for applications from Microsoft");
        dictionaryList.Add("CLR – managed execution environment for .NET");
        dictionaryList.Add("namespace – hierarchical organization of classes");

        bool hasMatch = false;

        foreach (string definition in dictionaryList)
        {
            for (int i = 0; i < word.Length; i++)
            {
                if (word[i] != definition[i])
                {
                    break;
                }
                hasMatch = true;
            }

            if (hasMatch)
            {
                Console.WriteLine(definition);
                break;
            }
        }

        if (!hasMatch)
        {
            Console.WriteLine("no definition for {0}", word);
        }
    }
}