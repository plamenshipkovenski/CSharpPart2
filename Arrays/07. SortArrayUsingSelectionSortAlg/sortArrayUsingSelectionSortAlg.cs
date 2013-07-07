using System;

class SortArrayUsingSelectionSortAlg
{
    //Sorting an array means to arrange its elements in increasing order. 
    //Write a program to sort an array.
    // Use the "selection sort" algorithm: 
    //Find the smallest element, move it at the first position,
    // find the smallest from the rest, move it at the second position, etc

    static void Main()
    {
        int[] myArray = AllocateArray();


        for (int i = 0; i < myArray.Length; i++)
        {
            int smallestMember = int.MaxValue;
            int smallestMemberIndex = 0;

            for (int j = i; j < myArray.Length; j++)
            {
                if (myArray[j] <= smallestMember)
                {
                    smallestMember = myArray[j];
                    smallestMemberIndex = j;
                }
            }

            int temp = myArray[i];
            myArray[i] = myArray[smallestMemberIndex];
            myArray[smallestMemberIndex] = temp;
        }

        PrintArray(myArray);
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

    private static void PrintArray(int[] myArray)
    {
        Console.WriteLine("array sorted:");

        for (int index = 0; index < myArray.Length; index++)
        {
            Console.WriteLine(myArray[index]);
        }
    }
}
