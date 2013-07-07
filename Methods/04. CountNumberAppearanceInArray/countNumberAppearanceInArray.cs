using System;

class CountNumberAppearanceInArray
{
    private static int CountAppearance(int[] arr, int numToCount)
    {
        int counter  = 0;

        foreach (var num in arr)
        {
            if (numToCount == num)
            {
                counter++;
            }
        }
        return counter;
    }

    static void Main()
    {
        Console.WriteLine("input array length: ");
        int arrLen = int.Parse(Console.ReadLine());
        int[] arr = new int[arrLen];

        for (int i = 0; i < arrLen; i++)
        {
            Console.Write("arr[{0}] = ", i);
            arr[i] = int.Parse(Console.ReadLine());
        }

        Console.Write("input integer: ");
        int number = int.Parse(Console.ReadLine());

        int numAppearance = CountAppearance(arr, number);

        Console.WriteLine("array holds {0} -> {1} times!", number, numAppearance);
    }
}