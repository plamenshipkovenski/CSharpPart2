using System;
using System.Text;

class AppendAsteriskIfStrLenIsLess20
{
    static void Main()
    {
        Console.WriteLine("input string (less than or equal 20 symbols):");
        string input = Console.ReadLine();

        if (input.Length <= 20)
        {
            StringBuilder sb = new StringBuilder(input);

            for (int i = input.Length; i < 20; i++)
            {
                sb.Append("*");
            }
            Console.WriteLine(sb.ToString());
        }
        else
        {
            Console.WriteLine("string has more than 20 symbols");
        }
    }
}