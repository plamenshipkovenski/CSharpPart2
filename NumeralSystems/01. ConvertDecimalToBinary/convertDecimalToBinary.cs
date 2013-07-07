using System;
using System.Text;

class ConvertDecimalToBinary
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
        Console.Write("input integer: ");
        int number = int.Parse(Console.ReadLine());
        int binBase = 2;

        StringBuilder sb = new StringBuilder();

        if (number == 0)
        {
            sb.Append('0');
        }
        else if (number > 0)
        {
            while (number > 0)
            {
                int bitValue = number % binBase;

                if (bitValue == 0)
                {
                    sb.Append('0');
                }
                else
                {
                    sb.Append('1');
                }

                number /= binBase;
            }

            sb = ReverseSB(sb);
        }
        else
        {
            //TODO negative 
        }

        Console.WriteLine(sb.ToString());
    }
}