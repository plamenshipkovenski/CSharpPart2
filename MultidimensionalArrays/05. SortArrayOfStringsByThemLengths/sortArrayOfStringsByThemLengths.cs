using System;
using System.Linq;
using System.Collections.Generic;

class SortArrayOfStringsByThemLengths
{
    static void Main()
    {
        string[] myTestArray = new string[] { "fr", "fff", "rrr", "hjkl", "wqer", "a", "aaa" };

        SortedDictionary<int, string> myDictonary = new SortedDictionary<int, string>();

        for (int i = 0; i < myTestArray.Length; i++)
        {
            if (myDictonary.ContainsKey(myTestArray[i].Length))
            {
                myDictonary[myTestArray[i].Length] += string.Format("{0} ", myTestArray[i]);
            }
            else
            {
                myDictonary.Add(myTestArray[i].Length, string.Format("{0} ", myTestArray[i]));
            }
        }

        foreach (var item in myDictonary)
        {
            Console.WriteLine(item.Value);
        }


        //string[] myTestArray = new string[] {"fr", "fff", "rrr", "hjkl", "wqer", "a", "aaa" };

        //var mySortedArray = myTestArray.OrderByDescending(x => x.Length);

        //foreach (var item in mySortedArray)
        //{
        //    Console.Write("{0} ", item);            
        //}
        
    }
}