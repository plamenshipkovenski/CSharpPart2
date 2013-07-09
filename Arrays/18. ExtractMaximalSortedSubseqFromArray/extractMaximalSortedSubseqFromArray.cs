using System;
using System.Collections.Generic;

namespace _18.ExtractMaximalSortedSubseqFromArray
{
    class ExtractMaximalSortedSubseqFromArray
    {
        static void Main(string[] args)
        {
            int[] arr = AllocateArray();

            List<List<int>> increasinSubseqList = new List<List<int>>();

            for (int i = 0; i < arr.Length; i++)
            {
                List<int> currentSeq = new List<int>();
                currentSeq.Add(arr[i]);

                for (int j = i + 1; j < arr.Length - 1; j++)
                {
                    bool isBigger = arr[j] >= currentSeq[currentSeq.Count - 1];
                    if (isBigger)
                    {
                        currentSeq.Add(arr[j]);
                    }
                }
                increasinSubseqList.Add(currentSeq);
            }

            foreach (var list in increasinSubseqList)
            {
                PrintList(list);
            }
        }

        private static void PrintList(List<int> list)
        {
            foreach (var item in list)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }

        private static int[] AllocateArray()
        {
            Console.WriteLine("input length:");
            int len = int.Parse(Console.ReadLine());

            int[] arr = new int[len];

            Console.WriteLine("input {0} integers", len);

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = int.Parse(Console.ReadLine());
            }

            return arr;
        }
    }
}
