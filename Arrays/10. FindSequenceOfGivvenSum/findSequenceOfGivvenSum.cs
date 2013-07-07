using System;
using System.Text;

class FindSequenceOfGivvenSum
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

        Console.Write("Input S: ");
        int sum = int.Parse(Console.ReadLine());

        int bestStart = 0;
        int bestEnd = 0;
        int tempSum = 0;
        bool hasSubset = false;

        for (int i = 0; i < myArray.Length; i++)
        {
            bestStart = i;

            for (int j = i; j < myArray.Length; j++)
            {
                tempSum += myArray[j];

                if (tempSum > sum)
                {
                    break;   
                }
                else if (tempSum == sum)
                {
                    hasSubset = true;
                    bestEnd = j;
                    break;
                }
            }

            if (hasSubset)
            {
                break;
            }
            tempSum = 0;
        }

        PrintFinalMessage(myArray, sum, bestStart, bestEnd, hasSubset);
    }

    private static void PrintFinalMessage(int[] myArray, int sum, int bestStart, int bestEnd, bool hasSubset)
    {
        StringBuilder finalMessage = new StringBuilder();
        finalMessage.Append("S = " + sum.ToString() + " -> ");
        if (hasSubset)
        {
            finalMessage.Append("{");
            for (int i = bestStart; i <= bestEnd; i++)
            {
                finalMessage.Append(myArray[i].ToString());
                if (i != bestEnd)
                {
                    finalMessage.Append(", ");
                }
            }
            finalMessage.Append("}");
        }
        else
        {
            finalMessage.Append("none!");
        }
        Console.WriteLine(finalMessage.ToString());
    }
}