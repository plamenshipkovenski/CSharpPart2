using System;

class BinarySearchImplementation
{
    private static int BinarySearch(int[] arr, int key, int startInd, int endInd)
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
        Console.Write("input length of array: ");
        int arrLength = int.Parse(Console.ReadLine());

        int[] myArray = new int[arrLength];
        Console.WriteLine("input {0} integers:", arrLength);

        for (int i = 0; i < myArray.Length; i++)
        {
            myArray[i] = int.Parse(Console.ReadLine());
        }

        //Binary Search needs SORTED array
        Array.Sort(myArray);
        Console.WriteLine("Array sorted:");
        foreach (var num in myArray)
        {
            Console.WriteLine(num);
        }

        Console.Write("input number to search for: ");
        int numKey = int.Parse(Console.ReadLine());

        int index = BinarySearch(myArray, numKey, 0, myArray.Length - 1);

        if (index >= 0)
        {
            Console.WriteLine("number {0} has index {1} in sorted array", numKey, index);
        }
        else
        {
            Console.WriteLine("number {0} not found in array!", numKey);
        }

    }
}
