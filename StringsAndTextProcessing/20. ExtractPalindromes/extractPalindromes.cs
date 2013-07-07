using System;
using System.Collections.Generic;
using System.Text;

class ExtractPalindromes
{

    private static bool IsPalindrome(StringBuilder currentWord)
    {
        bool isPalindrome = true;

        if (string.IsNullOrEmpty(currentWord.ToString().Trim()))
        {
            isPalindrome = false;
            return isPalindrome;
        }

        for (int i = 0, j = currentWord.Length - 1; i <= currentWord.Length / 2; i++, j--)
        {
            if (currentWord[i] != currentWord[j])
            {
                isPalindrome = false;
                break;
            }
        }
        return isPalindrome;
    }

    static void Main()
    {
        Console.WriteLine("input string:");
        string inputStr = Console.ReadLine();

        List<string> palindromesList = new List<string>();
        StringBuilder currentWord = new StringBuilder();

        for (int i = 0; i < inputStr.Length; i++)
        {
            char currentChar = inputStr[i];

            if (char.IsLetter(currentChar))
            {
                currentWord.Append(currentChar);

                if (i == inputStr.Length - 1)
                {
                    if (IsPalindrome(currentWord) && currentWord.Length > 1) //single letter is not palindrome
                    {
                        palindromesList.Add(currentWord.ToString());
                    }
                }
            }
            else
            {
                if (IsPalindrome(currentWord) && currentWord.Length > 1) //single letter is not palindrome
                {
                    palindromesList.Add(currentWord.ToString());
                }

                currentWord.Clear();
            }
        }

        foreach (string palindrome in palindromesList)
        {
            Console.WriteLine(palindrome);
        }
    }
}