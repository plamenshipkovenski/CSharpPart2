
using System;

class CreateArrayFillArray
{
    //Write a program that allocates array of 20 integers and initializes each element by its index multiplied by 5. Print the obtained array on the console

    private static void PrintArray(int[] arr)
    {
        foreach (var num in arr)
        {
            Console.WriteLine(num);
        }
    }

    static void Main()
    {
        int membersCount = 20;
        int multiplier = 5;

        int[] myArray = new int[membersCount];

        for (int index = 0; index < myArray.Length; index++)
        {
            myArray[index] = index * multiplier;
        }

        PrintArray(myArray);
    }
}
