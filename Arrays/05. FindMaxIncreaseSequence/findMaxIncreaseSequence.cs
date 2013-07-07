using System;

class FindMaxIncreaseSequence
{
    //Write a program that finds the maximal increasing sequence in an array

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

        int bestStartIndex = 0;
        int maxLength = 0;

        for (int index = 1; index < myArray.Length; index++)
        {
            int currentLength = 1;

            while (index < myArray.Length && myArray[index - 1] < myArray[index])
            {
                currentLength++;
                index++;
            }

            if (currentLength > maxLength)
            {
                maxLength = currentLength;
                bestStartIndex = index - maxLength;
            }
        }

        Console.WriteLine("maximal increasing sequence in array is:");

        for (int index = bestStartIndex; index < bestStartIndex + maxLength; index++)
		{
            Console.WriteLine(myArray[index]);
		}
    }
}
