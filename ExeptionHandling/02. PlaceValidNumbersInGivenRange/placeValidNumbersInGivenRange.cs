using System;
using System.Collections.Generic;

class PlaceValidNumbersInGivenRange
{

    private static void AddNumber(List<int> numbers, ref int start, ref int numsCount, ref int invalidInputs, int num)
    {
        if (num < 0)
        {
            numsCount++;
            invalidInputs++;
        }
        else
        {
            numbers.Add(num);
            start = num;
        }
    }

    private static int ReadNumber(int start, int end)
    {
        int number =  -1;

        try
        {
            number = int.Parse(Console.ReadLine());

            if (number <= start || end <= number)
            {
                number = -1;
                System.IO.StringWriter message = new System.IO.StringWriter();
                message.WriteLine("number is out of range [{0}...{1}]", start, end);
                throw new ArgumentOutOfRangeException(message.ToString());
            }

            //return number;
        }
        catch (ArgumentOutOfRangeException aoore)
        {
            Console.WriteLine(aoore.Message);
        }
        catch (ArgumentNullException ane)
        {
            Console.WriteLine(ane.Message);
        }
        catch (OverflowException oe)
        {
            Console.WriteLine(oe.Message);
        }
        catch (FormatException fe)
        {
            Console.WriteLine(fe.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        return number;
    }

    static void Main()
    {
        List<int> numbers = new List<int>();
        int start = 1;
        int end = 100;
        int numsCount = 10;
        int invalidInputs = 0;

        for (int i = 0; i < numsCount; i++)
        {
            int num = ReadNumber(start, end);// sets num to -1 if invalid input
            int inputsToReach = numsCount - invalidInputs;
            int possibleInputs = (end - start - 1);

            if (inputsToReach > possibleInputs)
            {
                AddNumber(numbers, ref start, ref numsCount, ref invalidInputs, num);
                break;
            }

            AddNumber(numbers, ref start, ref numsCount, ref invalidInputs, num);
        }

        Console.WriteLine("there are {0} valid inputs:", numbers.Count);
 
        foreach (var num in numbers)
        {
            Console.WriteLine(num);
        }
    }
}