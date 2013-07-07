using System;

class GreetPerson
{
    static void Main()
    {
        GreetSomeone();
    }

    static void GreetSomeone()
    {
        Console.Write("Please type your name: ");
        string name = Console.ReadLine();

        Console.WriteLine("Hello, {0}!", name);
    }
}