using System;

class SortArrayInAccendingOrDescendingOrder
{
    private static void PrintArr(int[] arr)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            Console.Write(arr[i] + " ");
        }
        Console.WriteLine();
    }

    private static int[] SortInDescendingOrder(int[] arr)
    {
        int[] arrSorted = arr;

        int currentMax = 0;
        int maxElemIndex = 0;

        for (int currentIndex = 0; currentIndex < arrSorted.Length; currentIndex++)
        {
            currentMax = GetMaxElement(arrSorted, currentIndex, arrSorted.Length - 1, ref maxElemIndex);

            if (arrSorted[currentIndex] < arrSorted[maxElemIndex])
            {
                SwapValues(ref arrSorted[currentIndex], ref arrSorted[maxElemIndex]);
            }
        }
        return arrSorted;
    }

    private static int[] SortInAccendingOrder(int[] arr)
    {
        int[] arrSorted = arr;

        int currentMax = 0;
        int maxElemIndex = 0;

        for (int currentIndex = arrSorted.Length - 1; currentIndex > 0; currentIndex--)
        {
            currentMax = GetMaxElement(arrSorted, 0, currentIndex, ref maxElemIndex);

            if (arrSorted[currentIndex] < arrSorted[maxElemIndex])
            {
                SwapValues(ref arrSorted[currentIndex], ref arrSorted[maxElemIndex]);
            }
        }
        return arrSorted;
    }

    private static void SwapValues(ref int a, ref int b)
    {
        a ^= b;
        b ^= a;
        a ^= b;
    }

    private static int GetMaxElement(int[] arr, int startIndex, int endIndex, ref int maxElemIndex)
    {
        int maxElem = int.MinValue;
        int currentElem = 0;

        for (int i = startIndex; i <= endIndex; i++)
        {
            currentElem = arr[i];
            if (currentElem > maxElem)
            {
                maxElem = currentElem;
                maxElemIndex = i;
            }
        }
        return maxElem;
    }

    static void Main()
    {
        Console.WriteLine("input array length: ");
        int arrLen = int.Parse(Console.ReadLine());
        int[] arr = new int[arrLen];

        for (int i = 0; i < arr.Length; i++)
        {
            Console.Write("arr[{0}] = ", i);
            arr[i] = int.Parse(Console.ReadLine());
        }

        int[] arrAccending = new int[arr.Length];
        Array.Copy(arr, arrAccending, arr.Length);

        SortInAccendingOrder(arrAccending);
        Console.WriteLine("array sorted in accending order:");
        PrintArr(arrAccending);

        int[] arrDescending = new int[arr.Length];
        Array.Copy(arr, arrDescending, arr.Length);

        SortInDescendingOrder(arrDescending);
        Console.WriteLine("array sorted in descending order:");
        PrintArr(arrDescending);
    }
}