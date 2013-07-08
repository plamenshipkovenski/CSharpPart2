using System;
using System.Collections.Generic;
using System.Text;

class FindSubsetWithGivenSumInArray
{
    //* We are given an array of integers and a number S.
    // Write a program to find if there exists a subset of the elements of the array that has a sum S

    private static string ComposeMessage(List<List<int>> subsetsList, int sum)
    {
        StringBuilder sb = new StringBuilder();

        if (subsetsList.Count == 0)
        {
            sb.Append("S = " + sum + " -> No");
        }
        else
        {
            foreach (var subset in subsetsList)
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
                if (subsetsList.IndexOf(subset) != subsetsList.Count - 1)
                {
                    sb.AppendLine();
                }
            }
        }
        return sb.ToString();
    }

    private static void AddSubset(int[] myArray, List<List<int>> subsetsList, string variantAsBinary)
    {
        List<int> subset = new List<int>();

        int member = 0;

        for (int k = 0; k < variantAsBinary.Length; k++)
        {
            if (variantAsBinary[k] == '1')
            {
                member = myArray[k];
                subset.Add(member);
            }
        }
        subsetsList.Add(subset);
    }

    private static int GetSum(int[] myArray, string variantAsBinary)
    {
        int sum = 0;

        for (int position = 0; position < variantAsBinary.Length; position++)
        {
            if (variantAsBinary[position] == '1')
            {
                sum += myArray[position];
            }
        }
        return sum;
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

        Console.Write("Input S: ");
        int sum = int.Parse(Console.ReadLine());

        List<List<int>> subsetsList = new List<List<int>>();

        int allVariants = (int)Math.Pow(2, myArray.Length) - 1;

        for (int subsetVariant = 1; subsetVariant <= allVariants; subsetVariant++)
        {
            string variantAsBinary = Convert.ToString(subsetVariant, 2);

            int tempSum = GetSum(myArray, variantAsBinary);

            if (tempSum == sum)
            {
                AddSubset(myArray, subsetsList, variantAsBinary);
            }
        }

        Console.WriteLine(ComposeMessage(subsetsList, sum));

        Console.WriteLine("There is {0} subsets with Sum = {1}", subsetsList.Count, sum);
    }

}
