using System;
using System.Collections.Generic;
using System.Linq;

class PrintListInAlphabeticalOrder
{
    static void Main()
    {
        Console.WriteLine("input string:");
        string inputStr = Console.ReadLine();

        string[] wordsArr = inputStr.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        IEnumerable<string> query = wordsArr.OrderBy(x => x).ToList();

        foreach (string word in query)
        {
            Console.WriteLine(word);
        }
    }
}