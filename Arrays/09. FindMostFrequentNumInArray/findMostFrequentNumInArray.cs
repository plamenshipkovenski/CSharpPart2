
using System;

class FindMostFrequentNumInArray
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

        bool[] checkedNumbersIndexes = new bool[myArray.Length];
        int mostFrequentNumCount = 0;
        int numValue = 0;

        for (int i = 0; i < myArray.Length; i++)
        {
            int counter = 0;

            for (int j = i; j < myArray.Length; j++)
            {
                if (!checkedNumbersIndexes[j])
                {
                    if (myArray[j] == myArray[i])
                    {
                        checkedNumbersIndexes[j] = true;
                        counter++;
                    }
                    if (counter > mostFrequentNumCount)
                    {
                        mostFrequentNumCount = counter;
                        numValue = myArray[j];
                    }
                }

            }
        }
        Console.Write("Most frequent number in array is: ");
        Console.WriteLine(numValue + " -> " + mostFrequentNumCount + " times");
    }
}