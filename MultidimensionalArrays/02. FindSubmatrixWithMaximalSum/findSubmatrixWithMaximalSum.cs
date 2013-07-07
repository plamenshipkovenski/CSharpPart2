using System;

class FindSubmatrixWithMaximalSum
{

    private static void PrintArray(int[,] arr)
    {
        for (int row = 0; row < arr.GetLength(0); row++)
        {
            for (int col = 0; col < arr.GetLength(1); col++)
            {
                Console.Write(arr[row, col] + " ");
            }
            Console.WriteLine();
        }
    }

    private static long FindSubsetWithMaxSum(int[,] rectangle, int submatrWidth, int submatrHeight)
    {
        int lastRowCheck = rectangle.GetLength(0) - submatrHeight;
        int lastColCheck = rectangle.GetLength(1) - submatrWidth;

        long maxSum = long.MinValue;

        for (int rectRow = 0; rectRow <= lastRowCheck; rectRow++)
        {
            for (int rectCol = 0; rectCol <= lastColCheck; rectCol++)
            {
                long tempSum = 0;

                int submatrLastCol = rectCol + submatrWidth;
                int submatrLastRow = rectRow + submatrHeight;

                for (int submatrRow = rectRow; submatrRow < submatrLastRow; submatrRow++)
                {
                    for (int submatrCol = rectCol; submatrCol < submatrLastCol; submatrCol++)
                    {
                        tempSum += rectangle[submatrRow, submatrCol];
                    }
                }

                if (tempSum > maxSum)
                {
                    maxSum = tempSum;
                }
            }
        }
        return maxSum;
    }

    static void Main()
    {
        Console.Write("Input width of rectangle: ");
        int rectCols = int.Parse(Console.ReadLine());

        Console.Write("Input heigth of rectangle: ");
        int rectRows = int.Parse(Console.ReadLine());

        int[,] rectangle = new int[rectRows, rectCols];

        Console.WriteLine("Fill Array!");
        for (int row = 0; row < rectangle.GetLength(0); row++)
        {
            for (int col = 0; col < rectangle.GetLength(1); col++)
            {
                Console.Write("Rectangle[row: {0} | col: {1}] = ", row, col);
                rectangle[row, col] = int.Parse(Console.ReadLine());
            }
        }

        int submatrWidth = 3;
        int submatrHeight = 3;

        if (rectRows >= submatrWidth && rectCols >= submatrWidth)
        {
            long maxsum = FindSubsetWithMaxSum(rectangle, submatrWidth, submatrHeight);

            PrintArray(rectangle);

            Console.WriteLine("maximal sum of submatrix[{0}, {1}] in rectangle is: {2}", submatrHeight, submatrWidth, maxsum);
        }
        else
        {
            Console.WriteLine("matrix[{0}, {1}] is not subsequence of rectangle[{2}, {3}]", submatrHeight, submatrWidth, rectRows, rectCols);
        }
    }
}