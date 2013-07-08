using System;
using System.Collections;
using System.Collections.Generic;

class GenerateAndPrintPermutationsFrom1ToN
{
    //* Write a program that reads a number N and generates and prints all the permutations of the numbers [1 … N]. 

    static void Main()
    {
        int startNum = 1;

        Console.Write("input N: ");
        int end = int.Parse(Console.ReadLine());

        int[] numbers = new int[end];

        for (int i = 0; i < end; i++)
        {
            numbers[i] = startNum;
            startNum++;
        }

        Queue<HashSet<int>> subsetsQueue = new Queue<HashSet<int>>();

        HashSet<int> emptySet = new HashSet<int>();

        subsetsQueue.Enqueue(emptySet);

        while (subsetsQueue.Count > 0)
        {
            HashSet<int> subset = subsetsQueue.Dequeue();

            if (subset.Count == numbers.Length)
            {
                //print current Subset of {Numbers.Length} members
                Console.Write("{ ");

                foreach (var member in subset)
                {
                    Console.Write("{0} ", member);
                }

                Console.WriteLine("}");
            }
            
            //Generate an enqueue all possible child subsets
            foreach (var num in numbers)
            {
                if (! subset.Contains(num))
                {
                    HashSet<int> newSubset = new HashSet<int>();
                        newSubset.UnionWith(subset);
                        newSubset.Add(num);
                        subsetsQueue.Enqueue(newSubset);
                }
            }
        }
    }
}