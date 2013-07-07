using System;
using System.Collections.Generic;
using System.Text;

class additionOfPositiveNumbers
{
    static void Main()
    {
        //TO DO ZERO ADDITION!!
        Console.Write("input positive integer: ");
        int num1 = int.Parse(Console.ReadLine());
        Console.Write("input positive integer: ");
        int num2 = int.Parse(Console.ReadLine());

        int[] arr1 = ConvertToArray(num1); //keeps digits of num in reversed order
        //PrintArr(arr1);
        int[] arr2 = ConvertToArray(num2); //keeps digits of num in reversed order
        //PrintArr(arr2);

        List<int> sumList = new List<int>(); //keeps digits of sum in reversed order
        int keep = 0;
        int digit = 0;

        SolveEqualLenParts(arr1, arr2, ref keep, sumList, ref digit);

        if (keep > 0)
        {
            if (arr1.Length == arr2.Length)
            {
                sumList.Add(keep);
            }
            else //find longest array
            {
                int start = 0;
                int end = 0;

                if (arr1.Length > arr2.Length)
                {
                    start = arr2.Length;
                    end = arr1.Length;

                    SolveDistancePart(arr1, sumList, ref keep, ref digit, start, end);
                }
                else
                {
                    start = arr1.Length;
                    end = arr2.Length;

                    SolveDistancePart(arr2, sumList, ref keep, ref digit, start, end);
                }
            }
        }
        long sum = ConvertListToInteger(sumList);
        Console.WriteLine("{0:000000000000}\n+\n{1:000000000000}\n_____________\n{2:000000000000} :{3}", num1, num2, sum, (long)num1 + (long)num2 == sum);
    }

    private static long ConvertListToInteger(List<int> sumList)
    {
        StringBuilder sb = new StringBuilder();

        for (int i = sumList.Count - 1; i >= 0; i--)
        {
            sb.Append(sumList[i]);
        }

        return long.Parse(sb.ToString());
    }

    private static void SolveDistancePart(int[] arr1, List<int> sumList, ref int keep, ref int digit, int start, int end)
    {
        for (int i = start; i < end; i++)
        {
            digit = FindDigitOnThisPosition(arr1[i], 0, keep);
            sumList.Add(digit);
            keep = GetKeep(arr1[i], 0, keep);
        }
        if (keep > 0)
        {
            sumList.Add(keep);
        }
    }

    private static void SolveEqualLenParts(int[] arr1, int[] arr2, ref int keep, List<int> sumList, ref int digit)
    {
        for (int index = 0; index < Math.Min(arr1.Length, arr2.Length); index++)
        {
            digit = FindDigitOnThisPosition(arr1[index], arr2[index], keep);
            sumList.Add(digit);
            keep = GetKeep(arr1[index], arr2[index], keep);
        }
    }

    private static int GetKeep(int num1, int num2, int keep)
    {
        int sum = num1 + num2 + keep;

        if (sum < 10)
        {
            return 0;
        }
        else if(10 <= sum && sum < 20)
        {
            return 1;
        }
        else
        {
            return 2;
        }
    }

    private static int FindDigitOnThisPosition(int digit1, int digit2, int keep)
    {
        int sum = digit1 + digit2 + keep;

        if (sum < 10)
        {
            return sum;
        }
        else if(10 <= sum && sum < 20)
        {
            return sum % 10;
        }
        else
        {
            return sum % 20;
        }
    }

    private static void PrintArr(int[] arr)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            Console.Write(arr[i] + " ");
        }
        Console.WriteLine();
    }

    private static int[] ConvertToArray(int num)
    {
        int numLen = GetNumLen(num);

        int[] numAsArray = new int[numLen];

        int digit = 0;
        for (int i = 0; i < numLen; i++)
        {
            digit = num % 10;
            numAsArray[i] = digit;
            num /= 10;
        }
        return numAsArray;
    }

    private static int GetNumLen(int num)
    {
        int numLen = 0;

        while (num > 0)
        {
            num /= 10;
            numLen++;
        }
        return numLen;
    }

    //private static void PrintSum(List<int> sumList)
    //{
    //    for (int i = sumList.Count - 1; i >= 0; i--)
    //    {
    //        Console.Write(sumList[i]);
    //    }
    //    Console.WriteLine();
    //}
}