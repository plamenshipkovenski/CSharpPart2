using System;

class CalcTriangleArea
{

    private static double CalcAreaByTwoSidesAnAngleBetween(double a, double b, int degrees)
    {
        double radians = Math.PI * degrees / 180.0;
        return a * b * Math.Sin(radians) / 2;
    }

    private static double CalcAreaByThreeSides(double a, double b, double c)
    {
        double semiPerimeter = (a + b + c) / 2;

        return Math.Sqrt(semiPerimeter * (semiPerimeter - a) * (semiPerimeter - b) * (semiPerimeter - c));
    }

    private static double CalcAreaBySideAndAltitude(double a, double h)
    {
        return a * h / 2;
    }

    private static int GetUserChoise()
    {
        string input = string.Empty;
        bool hasInput = false;
        int choise = 0;

        while (!hasInput)
        {
            Console.WriteLine("To calculate area by given side and altitude: press 1");
            Console.WriteLine("To calculate area by given three sides: press 2");
            Console.WriteLine("To calculate area by given two sides and angle between: press 3\n");
            input = Console.ReadLine();

            if (int.TryParse(input, out choise))
            {
                choise = int.Parse(input);

                if (choise == 1 || choise == 2 || choise == 3)
                {
                    hasInput = true;
                }
            }
        }
        return choise;
    }

    static void Main()
    {
        Console.WriteLine("Please choose method to calculate tiangle's area:\n");

        int userChoise = GetUserChoise();
        double area = new double();

        if (userChoise == 1)
        {
            Console.Write("input triangle's side: ");
            double a = double.Parse(Console.ReadLine());
            Console.Write("input altitude: ");
            double h = double.Parse(Console.ReadLine());

            area = CalcAreaBySideAndAltitude(a, h);
        }
        else if (userChoise == 2)
        {
            Console.Write("input triangle's first side: ");
            double a = double.Parse(Console.ReadLine());
            Console.Write("input triangle's second side: ");
            double b = double.Parse(Console.ReadLine());
            Console.Write("input triangle's third side: ");
            double c = double.Parse(Console.ReadLine());

            area = CalcAreaByThreeSides(a, b, c);
        }
        else if (userChoise == 3)
        {
            Console.Write("input triangle's first side: ");
            double a = double.Parse(Console.ReadLine());
            Console.Write("input triangle's second side: ");
            double b = double.Parse(Console.ReadLine());
            Console.Write("input angle between: ");
            int degrees = int.Parse(Console.ReadLine());

            area = CalcAreaByTwoSidesAnAngleBetween(a, b, degrees);
        }

        Console.WriteLine("Area: {0}", area);
    }
}