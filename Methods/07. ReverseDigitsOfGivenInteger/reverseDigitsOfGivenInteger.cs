using System;
using System.Text;

class reverseDigitsOfGivenInteger
{
    static void Main()
    {
        Console.Write("input number: ");
        int number = int.Parse(Console.ReadLine());
        int numReversed = 0;

        string sign = "";

        bool isNegative = number < 0;
        if (isNegative)
        {
            sign = "-";
            number *= -1;
            numReversed = ReverseDigits(number);
        }
        else
        {
            numReversed = ReverseDigits(number);
        }
        Console.WriteLine("number reversed: {0}{1}", sign, numReversed);
    }

    private static int ReverseDigits(int num)
    {
        StringBuilder sb = new StringBuilder();

        int lastDigit = 0;

        while (num > 0)
        {
            lastDigit = num % 10;
            sb.Append(lastDigit.ToString());
            num /= 10;
        }
        return int.Parse(sb.ToString());
    }
}