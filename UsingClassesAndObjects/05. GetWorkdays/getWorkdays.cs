using System;
using System.Collections.Generic;
using System.Threading;

class GetWorkdays
{
    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-Us");

        DateTime today = DateTime.Today;
        Console.WriteLine(today.ToShortDateString() + " {0:MMMM}", today);
        //Console.WriteLine("today is: {0:MMMM d.M.yyyy}", today);
        Console.WriteLine("input future date in month.day.year format:");
        string future = Console.ReadLine();

        DateTime futureDate = Convert.ToDateTime(future);
        TimeSpan timeSpan = futureDate - today;

        //Console.WriteLine(timeSpan.Days);
        int distance = int.Parse(timeSpan.Days.ToString());
        int workDays = 0;

        for (int i = 0; i < distance; i++)
        {
            if (!(today.DayOfWeek == DayOfWeek.Saturday || today.DayOfWeek == DayOfWeek.Sunday))
            {
                if (!IsPublicHoliday(today)) //set public holidays in here. used format : month/day/year
                {
                    workDays++;
                }
            }

            today = today.AddDays(1);
        }
        Console.WriteLine("workdays in this period: {0}", workDays);
    }

    private static bool IsPublicHoliday(DateTime date)
    {
        bool isHoliday = false;

        List<DateTime> publicHolidaysList = new List<DateTime>();

        //used format : month/day/year
        publicHolidaysList.Add(Convert.ToDateTime("7.4.2013"));
        publicHolidaysList.Add(Convert.ToDateTime("7.11.2013"));
        publicHolidaysList.Add(Convert.ToDateTime("7.12.2013"));
        publicHolidaysList.Add(Convert.ToDateTime("7.13.2013"));
        publicHolidaysList.Add(Convert.ToDateTime("7.14.2013"));

        foreach (var holiday in publicHolidaysList)
        {
            if (date.Equals(holiday))
            {
                isHoliday = true;
                break;
            }
        }
        return isHoliday;
    }
}