using System;

class FindSumOfNumbresInString
{
    static void Main()
    {
        Console.WriteLine("input positive integers separated by spaces:");
        string inputStr = Console.ReadLine();

        int sum = 0;
        string[] numsArr = inputStr.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        foreach (string numStr in numsArr)
        {
            sum += int.Parse(numStr);
        }

        Console.WriteLine("sum = {0}", sum);
    }
}