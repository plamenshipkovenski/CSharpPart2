using System;

class FindSequencewihMaxSum
{
    static void Main()
    {
        Console.Write("input length of array: ");
        int arrLength = int.Parse(Console.ReadLine());

        int[] myArray = new int[arrLength];
        Console.WriteLine("input {0} integers:", arrLength);

        for (int i = 0; i < myArray.Length; i++)
        {
            myArray[i] = int.Parse(Console.ReadLine());
        }

        //Kadane's algorithm : https://sites.google.com/site/computationalthinking/kadanealgorithm

        int start = 0;
        int end = 0;
        int maxSum = int.MinValue;
        int tempSum = 0;
        int tempStart = 0;

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

        Console.WriteLine("Sequence with maximal sum in array is:");

        //print sequence
        for (int i = start; i <= end; i++)
        {
            Console.WriteLine(myArray[i]);
        }
    }
}