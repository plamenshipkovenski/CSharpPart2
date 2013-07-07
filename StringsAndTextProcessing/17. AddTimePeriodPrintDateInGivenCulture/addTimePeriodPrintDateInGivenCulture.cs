using System;
using System.Threading;

class AddTimeToDatePrintsItInBGCulture
{
    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("bg-BG");
        Console.WriteLine("input date in day.month.year format");
        string dateInput = Console.ReadLine();
        int howrsToAdd = 6;
        int minutesToAdd = 30;

        string[] dateArr = dateInput.Split(new char[] { '.' });
        DateTime date = new DateTime(int.Parse(dateArr[2]), int.Parse(dateArr[1]), int.Parse(dateArr[0]));
        date.AddHours((double)(howrsToAdd));
        date.AddMinutes((double)(minutesToAdd));

        Console.WriteLine(string.Format("{0:dddd d.M.yyyy}", date));
    }
}