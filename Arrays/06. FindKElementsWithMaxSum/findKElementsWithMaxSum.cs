﻿using System;

class FindKElementsWithMaxSum
{
    //Write a program that reads two integer numbers N and K and an array of N elements from the console.
    // Find in the array those K elements that have maximal sum

    static void Main()
    {
        Console.WriteLine("Input N and K (K <= N):");
        Console.Write("input K: ");
        int elementsCount = int.Parse(Console.ReadLine());
        Console.Write("input N: ");
        int arrLength = int.Parse(Console.ReadLine());

        int[] myArr = new int[arrLength];

        Console.WriteLine("Input {0} integers:", arrLength);

        for (int index = 0; index < myArr.Length; index++)
        {
            myArr[index] = int.Parse(Console.ReadLine());
        }

        Array.Sort(myArr);

        Console.WriteLine("Elements With maximal sum in array are:");

        int lastIndex = myArr.Length - 1;

        for (int index = lastIndex; index > lastIndex - elementsCount; index--)
        {
            Console.WriteLine(myArr[index]);
        }
    }
}
