using System;

class FormatStrings
{
    static void Main()
    {
        Console.WriteLine("input integer:");
        string input = Console.ReadLine();

        PresentAsDecimal(input);
        PresentAsHexadecimal(input);//works only with integers
        PresentAsPercentage(input);
        PresentInScientificNotation(input);
    }

    private static void PresentInScientificNotation(string input)
    {
        Console.WriteLine("{0,15:E}", int.Parse(input));
    }

    private static void PresentAsPercentage(string input)
    {
        Console.WriteLine("{0,15:P}", double.Parse(input)/100);
    }
    
    private static void PresentAsHexadecimal(string input)
    {
        Console.WriteLine("{0,15:X}", int.Parse(input));
    }

    private static void PresentAsDecimal(string input)
    {
        Console.WriteLine("{0,15:D}", input);
    }
}