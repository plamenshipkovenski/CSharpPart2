using System;
using System.Text;

class ConvertFromAnyNumSystemToOther
{
    private static StringBuilder Reverse(StringBuilder sb)
    {
        StringBuilder reversed = new StringBuilder(sb.Length);

        for (int i = sb.Length - 1; i >= 0; i--)
        {
            reversed.Append(sb[i]);
        }
        return reversed;
    }

    private static char GetBaseYBitValue(int bitValue)
    {
        char value = new char();

        switch (bitValue)
        {
            case 0: value = '0'; break;
            case 1: value = '1'; break;
            case 2: value = '2'; break;
            case 3: value = '3'; break;
            case 4: value = '4'; break;
            case 5: value = '5'; break;
            case 6: value = '6'; break;
            case 7: value = '7'; break;
            case 8: value = '8'; break;
            case 9: value = '9'; break;
            case 10: value = 'A'; break;
            case 11: value = 'B'; break;
            case 12: value = 'C'; break;
            case 13: value = 'D'; break;
            case 14: value = 'E'; break;
            case 15: value = 'F'; break;
        }
        return value;
    }

    private static string ConvertDecimalToBaseY(int decNum, int baseY)
    {
        StringBuilder sb = new StringBuilder();
        int bitValue = 0;

        while (decNum > 0)
        {
            bitValue = decNum % baseY;

            sb.Append(GetBaseYBitValue(bitValue));//stores bitValues in reversed order

            decNum /= baseY;
        }

        sb = Reverse(sb);

        return sb.ToString();
    }

    private static int GetDecimalValue(char bitValue)
    {
        int decValue = 0;

        switch (bitValue)
        {
            case '0': decValue = 0; break;
            case '1': decValue = 1; break;
            case '2': decValue = 2; break;
            case '3': decValue = 3; break;
            case '4': decValue = 4; break;
            case '5': decValue = 5; break;
            case '6': decValue = 6; break;
            case '7': decValue = 7; break;
            case '8': decValue = 8; break;
            case '9': decValue = 9; break;
            case 'A': decValue = 10; break;
            case 'B': decValue = 11; break;
            case 'C': decValue = 12; break;
            case 'D': decValue = 13; break;
            case 'E': decValue = 14; break;
            case 'F': decValue = 15; break;
        }
        return decValue;
    }

    private static int ConvertToNumBase10(string numZ, int baseZ)
    {
        int num10 = 0;
        int bitDecValue = 0;

        for (int i = numZ.Length - 1, pow = 0; i >= 0; i--, pow++)
        {
            bitDecValue = GetDecimalValue(numZ[i]);
            num10 += bitDecValue * (int)Math.Pow(baseZ, pow);
        }
        return num10;
    }

    static void Main()
    {
        Console.Write("input numeral system base(2 <= base <= 16): ");
        int baseZ = int.Parse(Console.ReadLine());
        Console.Write("input number in numeral system({0}): ", baseZ);
        string numZ = Console.ReadLine().ToUpper();

        Console.Write("input numeral system base(2 <= base <= 16): ");
        int baseY = int.Parse(Console.ReadLine());

        int num10 = ConvertToNumBase10(numZ, baseZ);

        string numYStr = ConvertDecimalToBaseY(num10, baseY);

        Console.WriteLine();
        Console.WriteLine("number {0}\nin numeral system(base({1}))", numZ, baseZ);
        Console.WriteLine("is:");
        Console.WriteLine("number {0}\nin numeral system(base({1}))", numYStr, baseY);

        //http://www.cleavebooks.co.uk/scol/calnumba.htm //numSysConventer
    }
}