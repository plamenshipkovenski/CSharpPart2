using System;

class FindSequencewihMaxSum
{
    //Write a program that finds the sequence of maximal sum in given array. 

    static void Main()
    {
        int[] myArray = AllocateArray();

        //Kadane's algorithm : https://sites.google.com/site/computationalthinking/kadanealgorithm

        int start = 0, end = 0, maxSum = int.MinValue, tempSum = 0, tempStart = 0;

        for (int i = 0; i < myArray.Length; i++)
        {
            tempSum += myArray[i];

            if (tempSum > maxSum)
            {
                start = tempStart;
                end = i;
                maxSum = tempSum;
            }

            if (tempSum < 0)
            {
                tempSum = 0;
                tempStart = i + 1;
            }
        }

        PrintSequence(myArray, start, end);
    }

    private static void PrintSequence(int[] myArray, int start, int end)
    {
        Console.WriteLine("Sequence with maximal sum in array is:");

        for (int i = start; i <= end; i++)
        {
            Console.WriteLine(myArray[i]);
        }
    }

    private static int[] AllocateArray()
    {
        Console.Write("input length of array: ");
        int arrLength = int.Parse(Console.ReadLine());

        int[] myArray = new int[arrLength];
        Console.WriteLine("input {0} integers:", arrLength);

        for (int i = 0; i < myArray.Length; i++)
        {
            myArray[i] = int.Parse(Console.ReadLine());
        }
        return myArray;
    }
}