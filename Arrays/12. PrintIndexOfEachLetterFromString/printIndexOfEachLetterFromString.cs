using System;
using System.Text;

class PrintIndexOfEachLetterFromString
{
    //Write a program that creates an array containing all letters
    // from the alphabet (A-Z). Read a word from the console
    // and print the index of each of its letters in the array

    static void Main()
    {
        string word = GetWord();

        char[] alphabet = GetAlphabet();

        foreach (char letter in word)
        {
            Console.WriteLine("{0} -> {1}", letter.ToString(), (Array.BinarySearch(alphabet, letter) + 1) );//asume A has index 1 in alphabet
        }
    }

    private static string GetWord()
    {
        Console.WriteLine("Input Word: ");
        string word = Console.ReadLine().ToUpper();
        return word;
    }

    private static char[] GetAlphabet()
    {
        StringBuilder alphabetSB = new StringBuilder();

        for (int i = 'A'; i <= 'Z'; i++)
        {
            alphabetSB.Append(Convert.ToChar(i));
        }

        return alphabetSB.ToString().ToCharArray();
    }
}
