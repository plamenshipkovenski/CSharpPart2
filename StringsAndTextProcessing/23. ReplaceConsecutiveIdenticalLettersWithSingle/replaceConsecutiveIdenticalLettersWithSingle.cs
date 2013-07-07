using System;
using System.Text;

class ReplaceConsecutiveIdenticalLettersWithSingle
{
    static void Main()
    {
        Console.WriteLine("input string:");
        string inputStr = Console.ReadLine();

        StringBuilder sb = new StringBuilder();

        for (int i = 0; i < inputStr.Length - 1; i++)
        {
            if (inputStr[i] != inputStr[i + 1])
            {
                sb.Append(inputStr[i].ToString());
            }
        }

        sb.Append(inputStr[inputStr.Length - 1]);

        Console.WriteLine(sb.ToString());
    }
}