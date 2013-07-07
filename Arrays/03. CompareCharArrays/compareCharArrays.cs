using System;
using System.Linq;

class CompareCharArrays
{
    //Write a program that compares two char arrays lexicographically (letter by letter).

    private static char[] AllocateArr()
    {
        Console.Write("input length of array: ");
        int arrLen = int.Parse(Console.ReadLine());

        char[] arr = new char[arrLen];
        Console.WriteLine("input {0} chars:", arrLen);

        for (int i = 0; i < arr.Length; i++)
        {
            arr[i] = char.Parse(Console.ReadLine());
        }
        return arr;
    }

    static void Main()
    {
        char[] firstArr = AllocateArr();
        char[] secArr = AllocateArr();

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