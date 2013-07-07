using System;

class BinarySearchImplementation
{
    //Write a program that finds the index of given element in a sorted array of integers by using the binary search algorithm (find it in Wikipedia).

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

    private static int BinarySearch(int[] arr, int key, int startInd, int endInd) //recursive implementation
    {
        if (endInd < startInd)
        {
            return -1;
        }
        else
        {
            int middleInd = startInd + ((endInd - startInd) / 2);

            if (arr[middleInd] > key)
            {
                return BinarySearch(arr, key, startInd, middleInd - 1);
            }
            else if (arr[middleInd] < key)
            {
                return BinarySearch(arr, key, middleInd + 1, endInd);
            }
            else
            {
                return middleInd;
            }
        }
    }

    static void Main()
    {
        int[] myArray = AllocateArray();

        //Binary Search needs SORTED array
        Array.Sort(myArray);

        Console.Write("input number to search for: ");
        int numKey = int.Parse(Console.ReadLine());

        int index = BinarySearch(myArray, numKey, 0, myArray.Length - 1);

        if (index != -1)
        {
            Console.WriteLine("number {0} has found!", numKey, index);
        }
        else
        {
            Console.WriteLine("number {0} not found!", numKey);
        }
    }
}
