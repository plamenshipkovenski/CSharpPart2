using System;
using System.Linq;

class CompareArrays
{
    static void Main()
    {
        Console.Title = "Compare Two Arrays";

        Console.Write("input length of first array: ");
        int firstArrLength = int.Parse(Console.ReadLine());

        int[] firstArr = new int[firstArrLength];
        Console.WriteLine("input {0} integers:", firstArrLength);

        for (int i = 0; i < firstArr.Length; i++)
        {
            firstArr[i] = int.Parse(Console.ReadLine());
        }

        Console.Write("input length of second array: ");
        int secArrLength = int.Parse(Console.ReadLine());

        int[] secArr = new int[secArrLength];
        Console.WriteLine("input {0} integers:", secArrLength);

        for (int i = 0; i < secArr.Length; i++)
        {
            secArr[i] = int.Parse(Console.ReadLine());
        }

        //secArr = firstArr;//makes arrays same object
        bool hasSameReference = Enumerable.Equals(firstArr, secArr);//using System.Linq;

        if (hasSameReference)
        {
            Console.WriteLine("These arrays are equal objects!");
        }
        else
        {
            bool hasEqualMembersCount = firstArr.Length == secArr.Length;

            if (hasEqualMembersCount)
            {
                Array.Sort(firstArr);
                Array.Sort(secArr);

                bool areEqualsArrays = true;

                for (int index = 0; index < firstArr.Length; index++)
                {
                    if (firstArr[index] != secArr[index])
                    {
                        areEqualsArrays = false;

                        break;
                    }
                }

                if (areEqualsArrays)
                {
                    Console.WriteLine("These arrays are equals but they are two different objects!");
                }
                else
                {
                    Console.WriteLine("These arrays are not equals!");
                }
            }
            else
            {
                Console.WriteLine("These arrays are not equals!");
            }
        }
    }
}