using System;
using System.Collections.Generic;

class SieveOfEratosthenes
{
    //Write a program that finds all prime numbers in the range [1...10 000 000]. Use the sieve of Eratosthenes algorithm (find it in Wikipedia).

    static void Main()
    {
        int endInterval = 10000000;
        bool[] sieve = new bool[endInterval];

        sieve[0] = true;
        sieve[1] = true;

        int lastCheck = (int)Math.Sqrt(sieve.Length);

        for (int index = 2; index <= lastCheck; index++)
        {
            for (int j = index * index; j < sieve.Length; j += index)
            {
                if (!sieve[j])
                {
                    sieve[j] = true;
                }
            }
        }

        List<int> primesList = new List<int>();

        for (int index = 2; index < sieve.Length; index++)
        {
            if (!sieve[index])
            {
                primesList.Add(index);
                //Console.WriteLine(index);
            }
        }

        Console.WriteLine(primesList.Count);//test: http://primes.utm.edu/howmany.shtml
    }
}
