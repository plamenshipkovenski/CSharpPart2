using System;

class MaxSequenceOfEqualElements
{
    //Write a program that finds the maximal sequence of equal elements in an array.

    static void Main()
    {
        Console.Write("Input array Length: ");
        int arrLen = int.Parse(Console.ReadLine());

        int[] myArray = new int[arrLen];

        Console.WriteLine("input {0} integers:", myArray.Length);

        for (int index = 0; index < myArray.Length; index++)
        {
            myArray[index] = int.Parse(Console.ReadLine());
        }

        int maxSequenceStartIndex = 0;
        int maxSequenceLen = 0;

        int lastIndex = myArray.Length - 1;

        for (int index = 0; index <= lastIndex; )
        {
            int sequenceMembers = 1;

            for (int currentIndex = index; currentIndex < lastIndex && myArray[currentIndex] == myArray[currentIndex + 1]; currentIndex++)
            {
                sequenceMembers++;

                if (sequenceMembers > maxSequenceLen)
                {
                    maxSequenceLen = sequenceMembers;
                    maxSequenceStartIndex = index;
                }
            }

            index += sequenceMembers;
        }

        Console.WriteLine("maximal sequence with equal elements in array is: ");

        for (int index = maxSequenceStartIndex; index < maxSequenceStartIndex + maxSequenceLen; index++)
        {
            Console.WriteLine(myArray[index]);
        }
    }
}
