using System;

class ConvertBinaryToDecimal
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
        Console.Write("input binary: ");
        string binary = Console.ReadLine();
        binary.TrimStart('0');

        int binBase = 2;
        int number = 0;
        int bitValue = 0;

        for (int i = binary.Length - 1, bitPos = 0; i >= 0; i--, bitPos++)
        {
            bitValue = int.Parse(binary[i].ToString());
            number += bitValue * CalcPow(binBase, bitPos);
        }

        Console.WriteLine("decimal value of tnis binary is : {0}", number);
    }
}