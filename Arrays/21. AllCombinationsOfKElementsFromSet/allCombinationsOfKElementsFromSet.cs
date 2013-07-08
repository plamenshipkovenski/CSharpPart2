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

    //    setArray = new int[setLength];

    //    int setMember = 1;


    //    for (int i = 0; i < setArray.Length; i++)
    //    {
    //        setArray[i] = setMember++;
    //    }

    //    subset = new int[subsetLength];

        
    //    NestedLoops(0);
    //}   
    

    //static void NestedLoops(int currentLoop)
    //{
    //    if (currentLoop == subsetLength)
    //    {
    //        PrintLoops();
    //        return;
    //    }

    //    for (int counter = 0; counter < setArray.Length; counter++)
    //    {
    //        subset[currentLoop] = setArray[counter];
    //        NestedLoops(currentLoop + 1);
    //    }
    //}

    //static void PrintLoops()
    //{
    //    for (int i = 0; i < subsetLength; i++)
    //    {
    //        Console.Write("{0} ", subset[i]);
    //    }

    //    Console.WriteLine();
    //}
}
