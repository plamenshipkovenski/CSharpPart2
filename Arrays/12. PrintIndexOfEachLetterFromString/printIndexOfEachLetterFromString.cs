using System;
using System.Collections.Generic;
using System.Text;

class PrintIndexOfEachLetterFromString
{
    static void Main()
    {
        Console.WriteLine("Input Word: ");
        string word = Console.ReadLine().ToUpper();

        string alphabet = GetAlphabet();

        List<int> letterIndexes = new List<int>();

        foreach (var letter in word)
        {
            letterIndexes.Add(Array.BinarySearch(alphabet.ToCharArray(), letter));
        }

        foreach (int index in letterIndexes)
        {
            char letter = (char)(index + 65);
            Console.WriteLine("{0} -> {1}", letter.ToString(), index + 1);//asume A has index 1 //digits present as 0
        }
    }

    private static string GetAlphabet()
    {
        StringBuilder alphabet = new StringBuilder();

        for (int i = 65; i <= 90; i++)
        {
            alphabet.Append((char)i);
        }
        return alphabet.ToString();
    }
}
