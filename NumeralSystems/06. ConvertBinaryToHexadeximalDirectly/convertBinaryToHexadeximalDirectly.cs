using System;
using System.Text;

class ConvertBinaryToHexadeximalDirectly
{

    private static char GetHexValueOfHalfByte(StringBuilder currentHalfByte)
    {
        char value = new char();

        switch (currentHalfByte.ToString())
        {
            case "0000": value = '0'; break;
            case "0001": value = '1'; break;
            case "0010": value = '2'; break;
            case "0011": value = '3'; break;
            case "0100": value = '4'; break;
            case "0101": value = '5'; break;
            case "0110": value = '6'; break;
            case "0111": value = '7'; break;
            case "1000": value = '8'; break;
            case "1001": value = '9'; break;
            case "1010": value = 'A'; break;
            case "1011": value = 'B'; break;
            case "1100": value = 'C'; break;
            case "1101": value = 'D'; break;
            case "1110": value = 'E'; break;
            case "1111": value = 'F'; break;
        }
        return value;
    }

    static void Main()
    {
        Console.Write("input binary: ");
        string input = Console.ReadLine();
        int halfByteLen = 4;
        int bitsCount = input.Length % halfByteLen;//gets bits in most left halfByte

        StringBuilder binarySb = new StringBuilder();

        while ((bitsCount % halfByteLen) != 0)
        {
            binarySb.Append('0');
            bitsCount++;
        }

        binarySb.Append(input);

        StringBuilder hexSB = new StringBuilder(binarySb.Length);

        for (int i = 0; i < binarySb.Length; i += halfByteLen)
        {
            StringBuilder currentHalfByte = new StringBuilder(halfByteLen);
            int len = i + halfByteLen;

            for (int j = i; j < len; j++, i++)
            {
                currentHalfByte.Append(binarySb[j]);
            }

            i = len - halfByteLen;

            hexSB.Append(GetHexValueOfHalfByte(currentHalfByte));
        }

        Console.WriteLine("hexadecimal representation: {0}", hexSB);
    }
}