using System;
using System.Text;

class ConvertHexadecimalToDecimal
{
    private static int CalcPow(int num, int pow)
    {
        if (pow == 0)
        {
            return 1;
        }
        else if (pow == 1)
        {
            return num;
        }
        else
        {
            int result = 1;

            for (int i = 0; i < pow; i++)
            {
                result *= num;
            }
            return result;
        }
    }

    static void Main()
    {
        Console.Write("input hexadecimal number: ");
        string hexNum = Console.ReadLine().ToUpper();

        int bitValue = 0;
        int number = 0;
        int hexBase = 16;

        for (int i = hexNum.Length - 1, pow = 0; i >= 0; i--, pow++)
        {
            if (char.IsDigit(hexNum[i]))
            {
                bitValue = int.Parse(hexNum[i].ToString());
            }
            else
            {
                switch (hexNum[i])
                {
                    case 'A': bitValue = 10; break;
                    case 'B': bitValue = 11; break;
                    case 'C': bitValue = 12; break;
                    case 'D': bitValue = 13; break;
                    case 'E': bitValue = 14; break;
                    case 'F': bitValue = 15; break;
                }
            }

            number += bitValue * CalcPow(hexBase, pow);
        }
        Console.WriteLine("decimal representation: {0}", number);
    }
}