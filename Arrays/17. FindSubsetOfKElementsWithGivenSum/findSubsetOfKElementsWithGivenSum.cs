using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class FindSubsetOfKElementsWithGivenSum
{
    //* Write a program that reads three integer numbers N, K and S
    // and an array of N elements from the console.
    // Find in the array a subset of K elements that have sum S or indicate about its absence.

    private static string ComposeMessage(List<List<int>> validSubsetsList, int sum, int subseqLen)
    {
        StringBuilder sb = new StringBuilder();

        if (validSubsetsList.Count == 0)
        {
            sb.Append("There is not subsequence of {0} elements with sum {1} in this array", subseqLen, sum);
        }
        else
        {
            foreach (var subset in validSubsetsList)
            {
                sb.Append("S = " + sum + " -> yes (");

                for (int i = 0; i < subset.Count; i++)
                {
                    sb.Append(subset[i].ToString());

                    if (i < subset.Count - 1)
                    {
                        sb.Append("+");
                    }
                    else
                    {
                        sb.Append(")");
                    }
                }
                if (validSubsetsList.IndexOf(subset) != validSubsetsList.Count - 1)
                {
                    sb.AppendLine();
                }
            }
        }
        return sb.ToString();
    }

    private static void CompareSubseqSum(int[] myArray, List<List<int>> subsetsList, string variantAsBinary, int sum)
    {
        List<int> subsequence = new List<int>();

        for (int index = 0; index < variantAsBinary.Length; index++)
        {
            if (variantAsBinary[index] == '1')
            {
                subsequence.Add(myArray[index]);
            }
        }

        if (subsequence.Sum() == sum)
        {
            subsetsList.Add(subsequence);
        }
    }

    private static int CountTurnedOnBits(string variantAsBinary)
    {
        int bitsOn = 0;

        foreach (var bit in variantAsBinary)
        {
            if (bit == '1')
            {
                bitsOn++;
            }
        }
        return bitsOn;
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

    static void Main()
    {
        int[] myArray = AllocateArray();

        Console.Write("input length of subsequence: ");
        int subseqLen = int.Parse(Console.ReadLine());

        Console.Write("Input Sum to search for: ");
        int sum = int.Parse(Console.ReadLine());

        if (subseqLen > myArray.Length)
        {
            Console.WriteLine("There is not subsequence of {0} elements in array of {1} elements!", subseqLen, myArray.Length);
        }
        else
        {
            List<List<int>> validSubsetsList = new List<List<int>>();

            int allVariants = (int)Math.Pow(myArray.Length, 2) - 1;

            for (int variant = 1; variant <= allVariants; variant++)
            {
                string variantAsBinary = Convert.ToString(variant, 2);

                int bitsOnCounter = CountTurnedOnBits(variantAsBinary);

                if (bitsOnCounter == subseqLen)
                {
                    CompareSubseqSum(myArray, validSubsetsList, variantAsBinary, sum);
                }
            }

            Console.WriteLine(ComposeMessage(validSubsetsList, sum, subseqLen));
        }
    } 
}
