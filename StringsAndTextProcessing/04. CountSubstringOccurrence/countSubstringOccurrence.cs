using System;

class CountSubstringOccurrence //case insensitive
{

    private static int CountOccurrencies(string text, string subText)
    {
        if (subText.Length > text.Length || subText == "")
        {
            return 0;
        }
        else
        {
            int lenDiff = text.Length - subText.Length;
            int occurencies = 0;

            for (int i = text.IndexOf(subText); i < lenDiff; i++)
            {
                if (text.Substring(i, subText.Length).Equals(subText))
                {
                    occurencies++;
                    i += subText.Length - 1;
                }
            }
            return occurencies;
        }
    }

    static void Main()
    {
        Console.WriteLine("input text:");
        string text = Console.ReadLine().ToLower();

        Console.WriteLine("input value of substring to check for: ");
        string substr = Console.ReadLine().ToLower();

        int substrCounter = CountOccurrencies(text, substr);

        Console.WriteLine(substrCounter);
    }
}