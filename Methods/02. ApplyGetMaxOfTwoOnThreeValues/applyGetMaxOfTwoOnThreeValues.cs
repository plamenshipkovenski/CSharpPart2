using System;

class ApplyGetMaxOfTwoOnThreeValues
{
    private static int GetMax(int a, int b)
    {
        if (a > b)
        {
            return a;
        }
        else
        {
            return b;
        }
    }

    static void Main()
    {
        Console.WriteLine("input 3 integers");

        int firstNum = int.Parse(Console.ReadLine());
        int secNum = int.Parse(Console.ReadLine());
        int thirdNum = int.Parse(Console.ReadLine());

        int biggest = GetMax(firstNum, GetMax(secNum, thirdNum));

        Console.WriteLine("biggest is : {0}", biggest);
    }
}