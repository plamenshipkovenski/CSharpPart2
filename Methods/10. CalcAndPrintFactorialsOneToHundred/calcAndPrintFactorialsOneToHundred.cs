using System;
using System.Collections.Generic;
using System.Text;

class calcAndPrintFactorialsOneToHundred
{

    private static void CalcFactorial(int biggestFact, List<List<int>> factorialsList)
    {
        List<int> zeroFact = new List<int>();
        zeroFact.Add(-1);

        List<int> oneFact = new List<int>();
        oneFact.Add(1);

        factorialsList.Add(zeroFact);
        factorialsList.Add(oneFact);

        for (int i = 2; i <= biggestFact; i++)
        {
            List<int> factorial = new List<int>();
            factorial.Add(1);

            for (int j = i; j >= 2; j--)
            {
                List<int> multiple = ConvertToArray(j);

                factorial = Multiply(factorial, multiple);
            }
            factorialsList.Add(factorial);
        }
    }

    private static List<int> Multiply(List<int> mult1, List<int> mult2)
    {
        List<int> resultList = new List<int>();

        bool mult1IsZero = mult1[mult1.Count - 1] == 0;
        bool mult1IsOne = (mult1.Count == 1) && (mult1[0] == 1);

        bool mult2IsZero = mult2[mult2.Count - 1] == 0;
        bool mult2IsOne = (mult2.Count == 1) && (mult2[0] == 1);

        if (mult1IsZero || mult2IsZero)
        {
            resultList.Add(0);
        }
        else if (mult1IsOne || mult2IsOne)
        {
            if (mult1IsOne && mult2IsOne)
            {
                resultList.Add(1);
            }
            else if (mult1IsOne)
            {
                resultList = mult2;
            }
            else
            {
                resultList = mult1;
            }
        }
        else
        {
            resultList.Add(0);
            bool mult1IsBigger = false;
            bool mult1EqualsMult2 = false;

            List<int> addValueList = FindBigger(mult1, mult2, ref mult1IsBigger, ref mult1EqualsMult2);

            int end = 0;

            if (mult1EqualsMult2)
            {
                end = ConverToInteger(mult1);
            }
            else if (mult1IsBigger)
            {
                end = ConverToInteger(mult2);
            }
            else
            {
                end = ConverToInteger(mult1);
            }

            for (int i = 0; i < end; i++)
            {
                resultList = CalcSum(resultList, addValueList);
            }
        }
        return resultList;
    } //keeps digits in reversed order

    private static int ConverToInteger(List<int> arr)
    {
        StringBuilder sb = new StringBuilder();

        for (int i = arr.Count - 1; i >= 0; i--)
        {
            sb.Append(arr[i]);
        }
        return int.Parse(sb.ToString());
    }

    private static List<int> FindBigger(List<int> arr1, List<int> arr2, ref bool mult1IsBigger, ref bool mult1EqualsMult2)
    {
        List<int> biggerArr = new List<int>();

        if (arr1.Count == arr2.Count)
        {
            for (int i = arr1.Count - 1; i >= 0; i--)// start from last index, because digits of number are stored in array in rev order
            {
                if (arr1[i] > arr2[i])
                {
                    mult1IsBigger = true;
                    biggerArr = arr1;
                    break;
                }
                if (arr2[i] > arr1[i])
                {
                    biggerArr = arr2;
                    break;
                }
                if (i == 0) // here arrays are equal
                {
                    mult1EqualsMult2 = true;
                    biggerArr = arr1;
                }
            }
        }
        else
        {
            if (arr1.Count > arr2.Count)
            {
                mult1IsBigger = true;
                biggerArr = arr1;
            }
            else
            {
                biggerArr = arr2;
            }
        }
        return biggerArr;
    }

    private static List<int> CalcSum(List<int> arr1, List<int> arr2)
    {
        List<int> sumList = new List<int>(); //keeps digits of sum in reversed order
        int keep = 0;
        int digit = 0;

        if (arr1[arr1.Count - 1] == 0 || arr2[arr2.Count - 1] == 0)
        {
            if (arr1[arr1.Count - 1] == 0 && arr2[arr2.Count - 1] == 0)
            {
                sumList.Add(0);
            }
            else if (arr1[arr1.Count - 1] == 0)
            {
                sumList = arr2;
            }
            else
            {
                sumList = arr1;
            }
        }
        else
        {
            SolveEqualLenParts(arr1, arr2, ref keep, sumList, ref digit);

            if (arr1.Count == arr2.Count)
            {
                if (keep > 0)
                {
                    sumList.Add(keep);
                }
            }
            else //find longest array
            {
                int start = 0;
                int end = 0;

                if (arr1.Count > arr2.Count)
                {
                    start = arr2.Count;
                    end = arr1.Count;

                    SolveDistancePart(arr1, sumList, ref keep, ref digit, start, end);
                }
                else
                {
                    start = arr1.Count;
                    end = arr2.Count;

                    SolveDistancePart(arr2, sumList, ref keep, ref digit, start, end);
                }
            }
        }
        return sumList;
    } //keeps digits in reversed order

    private static void SolveDistancePart(List<int> arr, List<int> sumList, ref int keep, ref int digit, int start, int end)
    {
        for (int i = start; i < end; i++)
        {
            digit = FindDigitOnThisPosition(arr[i], 0, keep);
            sumList.Add(digit);
            keep = GetKeep(arr[i], 0, keep);
        }
        if (keep > 0)
        {
            sumList.Add(keep);
        }
    }

    private static void SolveEqualLenParts(List<int> arr1, List<int> arr2, ref int keep, List<int> sumList, ref int digit)
    {
        for (int index = 0; index < Math.Min(arr1.Count, arr2.Count); index++)
        {
            digit = FindDigitOnThisPosition(arr1[index], arr2[index], keep);
            sumList.Add(digit);
            keep = GetKeep(arr1[index], arr2[index], keep);
        }
    }

    private static int GetKeep(int num1, int num2, int keep)
    {
        int sum = num1 + num2 + keep;

        if (sum < 10)
        {
            return 0;
        }
        else if (10 <= sum && sum < 20)
        {
            return 1;
        }
        else
        {
            return 2;
        }
    }

    private static int FindDigitOnThisPosition(int digit1, int digit2, int keep)
    {
        int sum = digit1 + digit2 + keep;

        if (sum < 10)
        {
            return sum;
        }
        else if (10 <= sum && sum < 20)
        {
            return sum % 10;
        }
        else
        {
            return sum % 20;
        }
    }

    private static List<int> ConvertToArray(int num)
    {
        List<int> numAsArray  = new List<int>();
        if (num == 0)
        {
            numAsArray.Add(0);
            return numAsArray;
        }
        else
        {
            int numLen = GetNumLen(num);

            int digit = 0;
            for (int i = 0; i < numLen; i++)
            {
                digit = num % 10;
                numAsArray.Add(digit);
                num /= 10;
            }
            return numAsArray;
        }
    } //keeps digits in reversed order

    private static int GetNumLen(int num)
    {
        int numLen = 0;

        while (num > 0)
        {
            num /= 10;
            numLen++;
        }
        return numLen;
    }

    private static void PrintList(List<int> num)
    {
        for (int i = num.Count - 1; i >= 0; i--)
        {
            Console.Write(num[i]);
        }
        Console.WriteLine();
    }

    static void Main()
    {
        Console.Title = "Generate Factorials";
        Console.WriteLine("I'll generate all factorials from 1...to:\n");

        Console.Write("input value of biggest factorial to generate: ");
        int biggestFact = int.Parse(Console.ReadLine());
        Console.WriteLine();

        Console.Title = "&&**$#$@#$#$%^&^#@%";

        List<List<int>> factorialsList = new List<List<int>>();

        CalcFactorial(biggestFact, factorialsList);

        for (int i = 300; i < 500; i += 50)
        {  
            Console.Beep(i, 100);
        }
        Console.WriteLine("all factorials (1...{0}) Genetared!\n", biggestFact);

        Console.WriteLine("Let's use some of them!!");

        Console.Title = "to exit press 'esc'";

        while (true)
        {
            ConsoleKeyInfo keyPressed = Console.ReadKey(true);

            if (keyPressed.Key != ConsoleKey.Escape)
            {
                Console.Write("input factorial (1...{0}) to calc: ", biggestFact);
                int factToPrint = int.Parse(Console.ReadLine());

                Console.WriteLine("-------{0}!-------", factToPrint);
                PrintList(factorialsList[factToPrint]);
            }
            Console.WriteLine("Press any key ;) to continue");
        }
    }
}