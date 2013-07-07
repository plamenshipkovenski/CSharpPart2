using System;

class findLargestNumEqualOrSmallerThanGivenNum
{
    private static void PrintArray(int[] numbers)
    {
        Console.WriteLine("--ORDERED--");
        for (int i = 0; i < numbers.Length; i++)
        {
            Console.WriteLine("numbers [{0}]= {1}", i, numbers[i]);
        }
    }

    static void Main()
    {

        Console.Write("input numbers Count: ");
        int numsCount = int.Parse(Console.ReadLine());
        int[] numbers = new int[numsCount];

        for (int i = 0; i < numbers.Length; i++)
        {
            Console.Write("numbers[{0}] = ", i);
            numbers[i] = int.Parse(Console.ReadLine());
        }

        Console.Write("input number to look for: ");
        int numToFind = int.Parse(Console.ReadLine());

        Array.Sort(numbers);
        PrintArray(numbers);

        Console.WriteLine();

        int value = Array.BinarySearch(numbers, numToFind);
        int index = 0;

        if (value >= 0)// num exist in array
        { 
            index = value;
            numToFind = numbers[index];
            Console.WriteLine("number {0} exist in array!", numToFind);
            Console.WriteLine("{0} index: {1}", numToFind, index);

        }
        else//solve value: negative
        {
            int position = Math.Abs(value);
            index = position - 1;
            Console.WriteLine("/if {0} should be placed in array, in a way\nthat array stays ordered it should be placed on array[{1}]/", numToFind, index);
            Console.WriteLine();

            //for this task
            index -= 1;

            Console.WriteLine("number {0} Not Found!", numToFind);
            if (index <= 0)
            {
                Console.WriteLine("in this array there is no number K(K <= {0})", numToFind);
            }
            else
            {
                Console.WriteLine("{0} is number in array that have closest value to {1}", numbers[index], numToFind);
            }
        }
    }
}