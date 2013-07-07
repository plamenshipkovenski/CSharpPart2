using System;

class CalcTimeDistanceInDays
{
    static void Main()
    {
        Console.WriteLine("input 2 dates in day.month.year format");
        Console.Write("first date: ");
        string date1 = Console.ReadLine();
        Console.Write("second date: ");
        string date2 = Console.ReadLine();

        string[] d1Arr = date1.Split('.');
        string[] d2Arr = date2.Split('.');

        DateTime firstDate = new DateTime(int.Parse(d1Arr[2]), int.Parse(d1Arr[1]), int.Parse(d1Arr[0]));
        DateTime secDate = new DateTime(int.Parse(d2Arr[2]), int.Parse(d2Arr[1]), int.Parse(d2Arr[0]));

        TimeSpan distanceInDaysTimeSpan = secDate - firstDate;// trows negative result if secDate is before firstDate

        Console.WriteLine("distance in days: {0}", Math.Abs(distanceInDaysTimeSpan.Days));
    }
}