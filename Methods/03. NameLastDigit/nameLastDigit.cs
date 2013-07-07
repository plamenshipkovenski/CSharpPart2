using System;

class NameLastDigit
{
    private static int ExtractLastDigit(int num)
    {
        return (Math.Abs(num) % 10);
    }

    private static string GetName(int digit)
    {
        string name = "";

        switch (digit)
        {
            case 1: name = "one"; break;
            case 2: name = "two"; break;
            case 3: name = "three"; break;
            case 4: name = "four"; break;
            case 5: name = "five"; break;
            case 6: name = "six"; break;
            case 7: name = "seven"; break;
            case 8: name = "eighth"; break;
            case 9: name = "nine"; break;
            case 0: name = "zero"; break;
        }
        return name;
    }

    static void Main()
    {
        Console.WriteLine("input integer:");
        int number = int.Parse(Console.ReadLine());
        string lastDigitName = GetName(ExtractLastDigit(number));
        Console.WriteLine("{0} -> \"{1}\"", number, lastDigitName);
    }
}