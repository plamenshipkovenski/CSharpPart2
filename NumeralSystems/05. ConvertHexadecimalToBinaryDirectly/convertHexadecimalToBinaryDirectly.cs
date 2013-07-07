using System;
using System.Text;

class ConvertHexadecimalToBinaryDirectly
{
    static void Main()
    {
        Console.Write("input hexadecimal number: ");
        string hexNum = Console.ReadLine().ToUpper();

        if (hexNum == "0")
        {
            Console.WriteLine(0);
        }
        else
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < hexNum.Length; i++)
            {
                switch (hexNum[i])
                {
                    case '0': sb.Append("0000"); break;
                    case '1': sb.Append("0001"); break;
                    case '2': sb.Append("0010"); break;
                    case '3': sb.Append("0011"); break;
                    case '4': sb.Append("0100"); break;
                    case '5': sb.Append("0101"); break;
                    case '6': sb.Append("0110"); break;
                    case '7': sb.Append("0111"); break;
                    case '8': sb.Append("1000"); break;
                    case '9': sb.Append("1001"); break;
                    case 'A': sb.Append("1010"); break;
                    case 'B': sb.Append("1011"); break;
                    case 'C': sb.Append("1100"); break;
                    case 'D': sb.Append("1101"); break;
                    case 'E': sb.Append("1110"); break;
                    case 'F': sb.Append("1111"); break;
                }
            }

            Console.WriteLine(sb.ToString().TrimStart('0'));
        }
    }
}