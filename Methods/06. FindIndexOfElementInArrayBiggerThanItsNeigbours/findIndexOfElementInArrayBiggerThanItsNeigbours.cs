using System;

class FindIndexOfElementInArrayBiggerThanItsNeigbours
{
    private static bool IsBiggerThan(int[] arr, int elemIndex, int index)
    {
        int neigbourIndex = elemIndex + index;

        if (arr[elemIndex] > arr[neigbourIndex])
        {
            return true;
        }
        return false;
    }

    private static int GetIndexOfNumBiggerThanNeigbours(int[] arr)
    {
        int index = -1;

        int previousInd = -1;
        int nextInd = 1;


        for (int currentInd = 1; currentInd < arr.Length - 1; currentInd++)
        {
            bool hasFoundNum = IsBiggerThan(arr, currentInd, previousInd) && IsBiggerThan(arr, currentInd, nextInd);
            if (hasFoundNum)
            {
                index = currentInd;
                break;
            }
        }
        return index;
    }

    static void Main(string[] args)
    {
        Console.WriteLine("input array length: ");
        int arrLen = int.Parse(Console.ReadLine());
        int[] arr = new int[arrLen];

        for (int i = 0; i < arrLen; i++)
        {
            Console.Write("arr[{0}] = ", i);
            arr[i] = int.Parse(Console.ReadLine());
        }

        int index = GetIndexOfNumBiggerThanNeigbours(arr);

        if (index > 0)
        {
            int number = arr[index];

            Console.WriteLine("arr[{0}] = {1}, is bigger than its neigbours", index, number);
            Console.WriteLine("left neigbour: arr[{0}] = {1}", index - 1, arr[index - 1]);
            Console.WriteLine("right neigbour: arr[{0}] = {1}", index + 1, arr[index + 1]);
        }
        else
        {
            Console.WriteLine("no such number!");
        }
    }
}