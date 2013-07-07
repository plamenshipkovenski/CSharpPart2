using System;

class SortArrayUsingSelectionSortAlg
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


        for (int index = 0; index < myArray.Length; index++)
        {
            int smallestMember = int.MaxValue;
            int smallestMemberIndex = 0;

            for (int currentIndex = index; currentIndex < myArray.Length; currentIndex++)
            {
                if (myArray[currentIndex] <= smallestMember)
                {
                    smallestMember = myArray[currentIndex];
                    smallestMemberIndex = currentIndex;
                }
            }
            int temp = myArray[index];
            myArray[index] = myArray[smallestMemberIndex];
            myArray[smallestMemberIndex] = temp;
        }

        //print array
        Console.WriteLine("array sorted:");

        for (int index = 0; index < myArray.Length; index++)
        {
            Console.WriteLine(myArray[index]);
        }
    }
}
