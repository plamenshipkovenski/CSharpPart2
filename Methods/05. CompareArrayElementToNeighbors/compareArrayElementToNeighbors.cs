using System;

class CompareArrayElementToNeighbors
{
    private static bool IsBiggerThan(int[] arr, int elemPos, int dx)
    {
        int otherIndex = elemPos + dx;

        if (arr[elemPos] > arr[otherIndex])
        {
            return true;
        }
        return false;
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

        Console.Write("input element position(0 <= pos <= {0}): ", arr.Length - 1);
        int numIndex = int.Parse(Console.ReadLine());

        bool hasRightNeighbor = numIndex < arr.Length - 1;
        bool hasLeftNeighbor = numIndex > 0;

        if (hasLeftNeighbor && hasRightNeighbor)
        {
            bool firstCondition = IsBiggerThan(arr, numIndex, -1);
            bool secCondition = IsBiggerThan(arr, numIndex, 1);

            Console.WriteLine("{3}! {0} < {1} > {2}", arr[numIndex - 1], arr[numIndex], arr[numIndex + 1], firstCondition && secCondition);
        }
        else
        {
            if (hasLeftNeighbor)
            {
                Console.WriteLine("no right neighbour!");
            }
            if (hasRightNeighbor)
            {
                Console.WriteLine("no left neighbour!");
            }
        }
    }
}