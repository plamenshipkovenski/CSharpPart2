using System;
using System.Linq;

class CompareArrays
{
    //Write a program that reads two arrays from the console and compares them element by element.


    private static int[] AllocateArr()
    {
        Console.Write("input length of array: ");
        int arrLen = int.Parse(Console.ReadLine());

        int[] arr = new int[arrLen];
        Console.WriteLine("input {0} integers:", arrLen);

        for (int i = 0; i < arr.Length; i++)
        {
            arr[i] = int.Parse(Console.ReadLine());
        }
        return arr;
    }

    static void Main()
    {
        Console.Title = "Compare Two Arrays";

        int[] firstArr = AllocateArr();

        int[] secArr = AllocateArr();

        //secArr = firstArr;//makes arrays same object
        bool hasSameReference = Enumerable.Equals(firstArr, secArr);//using System.Linq;

        bool areEqualArrays = true;

        if (hasSameReference)
        {
            Console.WriteLine("These arrays are equal objects!");
        }
        else
        {
            bool hasEqualMembersCount = firstArr.Length == secArr.Length;

            if (hasEqualMembersCount)
            {
                for (int i = 0; i < firstArr.Length; i++)
                {
                    if (firstArr[i] != secArr[i])
                    {
                        areEqualArrays = false;
                        break;
                    }
                }
            }
            else
            {
                areEqualArrays = false;
            }
        }


        if (areEqualArrays)
        {
            Console.WriteLine("these arrays are equal!");
        }
        else
        {
            Console.WriteLine("these arrays are different!");
        }
    }
}