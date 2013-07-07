using System;

class CheckLeapYear
{
    static void Main()
    {
        Console.Write("input year: ");
        int year = int.Parse(Console.ReadLine());

        if (DateTime.IsLeapYear(year))
        {
            Console.WriteLine("{0} is leap year!", year);
        }
        else
        {
            Console.WriteLine("{0} is not leap year!", year);
        }
    }
}