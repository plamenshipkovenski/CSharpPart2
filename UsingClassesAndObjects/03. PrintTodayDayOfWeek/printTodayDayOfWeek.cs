using System;

class PrintTodayDayOfWeek
{
    static void Main()
    {
        Console.WriteLine("Today is {0}!", DateTime.Now.DayOfWeek.ToString().ToLower());
    }
}