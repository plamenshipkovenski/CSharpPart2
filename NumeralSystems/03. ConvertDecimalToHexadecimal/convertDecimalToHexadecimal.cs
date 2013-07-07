using System;
using System.Text;

class ConvertDecimalToHexadecimal
{
    private static StringBuilder ReverseSB(StringBuilder sb)
    {
        StringBuilder reversedSB = new StringBuilder(sb.Length);

        for (int i = sb.Length - 1; i >= 0; i--)
        {
            reversedSB.Append(sb[i]);
        }

        return reversedSB;
    }

    static void Main()
    {
        Console.Write("input number: ");
        int number = int.Parse(Console.ReadLine());
        int hexBase = 16;

        int remainder = 0;
        StringBuilder sb = new StringBuilder();

        if (number == 0)
        {
            sb.Append('0');
        }
        else
        {
            while (number > 0)
            {
                remainder = number % hexBase;

                if (remainder > 9)
                {
                    switch (remainder)
                    {
                        case 10: sb.Append('A'); break;
                        case 11: sb.Append('B'); break;
                        case 12: sb.Append('C'); break;
                        case 13: sb.Append('D'); break;
                        case 14: sb.Append('E'); break;
                        case 15: sb.Append('F'); break;
                    }
                }
                else
                {
                    sb.Append(remainder.ToString());
                }

                number /= hexBase;
            }
        }
        
        sb = ReverseSB(sb);

        Console.WriteLine("hexadeicmal representation: {0}", sb.ToString());
    }
}