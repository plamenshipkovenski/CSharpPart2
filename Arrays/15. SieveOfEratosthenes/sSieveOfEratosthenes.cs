using System;

class SieveOfEratosthenes
{
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

        int primesCounter = 0;
        for (int index = 0; index < sieve.Length; index++)
        {
            if (!sieve[index])
            {
                primesCounter++;
                //Console.WriteLine(index);
            }
        }
        Console.WriteLine(primesCounter);//test: http://primes.utm.edu/howmany.shtml
    }
}
