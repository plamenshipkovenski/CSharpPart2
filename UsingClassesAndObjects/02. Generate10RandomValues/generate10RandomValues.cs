using System;

class Generate10RandomValues
{
    static void Main()
    {
        Console.Title = "these are ten random values[100..200]";

        Random rand = new Random();

        int randNum = 0;

        for (int i = 0; i < 10; i++)
        {
            randNum = rand.Next(100, 201);
            Console.WriteLine(randNum);
        }
    }
}