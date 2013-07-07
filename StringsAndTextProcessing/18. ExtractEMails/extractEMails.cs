using System;
using System.Text.RegularExpressions;

class ExtractEMails
{
    static void Main()
    {
        Console.WriteLine("input string:");
        string inputStr = Console.ReadLine();

        Regex emailRegex = new Regex(@"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", RegexOptions.IgnoreCase);

        MatchCollection emailsMatches = emailRegex.Matches(inputStr);

        foreach (var email in emailsMatches)
        {
            Console.WriteLine(email);
        }
    }
}