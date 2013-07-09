using System;

class allCombinationsOfKElementsFromSet
{
    static int subsetLength;
    static int setLength;
    static int[] subset;
    static int[] setArray;

    static void Main()
    {
        Console.Write("input count of subset members: ");
        subsetLength = int.Parse(Console.ReadLine());//K

        Console.Write("input count of set members: ");
        setLength = int.Parse(Console.ReadLine());//N
    }
}
