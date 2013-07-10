using System;
using System.Collections.Generic;
using System.Threading;

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
            if (!sieve[index])
            {
                for (int j = index * index; j < sieve.Length; j += index)
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
            }
        }

        Console.WriteLine(primesList.Count);//test: http://primes.utm.edu/howmany.shtml
        RithmOfPrimes(primesList); 
    }

    private static void RithmOfPrimes(List<int> primesList)
    {
        int frequency = 440;
        int duration = 170;

        foreach (var prime in primesList)
        {
            Console.Clear();
            Thread.Sleep(duration + 1); //allows to hear full sound duration
            Console.WriteLine(prime);

            if (HasEvenDigitInLast2Digits(prime, ref frequency))
            {
                Console.Beep(frequency, duration << 1);
            }
            else
            {
                Console.Beep(frequency, duration);
            }
        }
    }

    private static bool HasEvenDigitInLast2Digits(int prime, ref int frequency)
    {
        int count = 0;
        int len = 2;

        while (count++ < len)
        {
            int digit = prime % 10;

            if ((digit & 1) == 0 && digit != 0)
            {
                frequency = GetFrequency(digit);
                return true;
            }

            frequency = GetFrequency(digit);
            prime /= 10;
        }
        
        return false;
    }

    private static int GetFrequency(int digit)
    {
        int frequency = 0;

        switch (digit) //http://www.phy.mtu.edu/~suits/notefreqs.html
        {
                // sqrt is integer
            case 1:
            case 4:
            case 9: frequency = 392/*g4*/; break;

                //prime
            case 2: 
            case 3:
            case 5:
            case 7: frequency = 494/*b4*/; break;

                //composite
            case 6:
            case 8: frequency = 440/*a4*/; break;

                //zero
            case 0: frequency = 294/*d4*/; break;
        }
        return frequency;
    }
}
