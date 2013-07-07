using System;

class PrintSquareRoot
{
    static void Main()
    {
        try
        {
            double num = GetInput();

            if (num < 0)
            {
                throw new IndexOutOfRangeException();
            }

            double sqrt = Math.Sqrt(num);
            Console.WriteLine("square root: {0}", sqrt);
        }
        catch (IndexOutOfRangeException)
        {
            Console.WriteLine("invalid number IndexOutOfRangeException");
        }
        finally 
        {
            Console.WriteLine("Good bye!");
        }
    }

    private static double GetInput()
    {
        double num = -1;
        try
        {
            Console.Write("input number: ");
            string input = Console.ReadLine();
            num = double.Parse(input);
        }
        catch (ArgumentNullException)
        {
            Console.WriteLine("invalid number ArgumentNullException");
        }
        catch (OverflowException)
        {
            Console.WriteLine("invalid number OverflowException");
        }
        catch (FormatException)
        {
            Console.WriteLine("invalid number FormatException");
        }
        catch (Exception)
        {
            Console.WriteLine("invalid number Exception");
        }
        return num;
    }
}