using System;

class AccessEachElementInSpecificOrder
{
    private static int[,] matrix;
    private static int n;

    private static void PrintArray(int[,] arr)
    {
        // Method to print arrays, pads numbers so they line up in columns
        int x = (arr.GetLength(0) * arr.GetLength(1) - 1).ToString().Length + 1;

        for (int row = 0; row < arr.GetLength(0); row++)
        {
            for (int col = 0; col < arr.GetLength(1); col++)
            {
                Console.Write(arr[row, col].ToString().PadLeft(x, ' '));
            }
            Console.WriteLine();
        }
    }

    private static void EachColTopToBottom()
    {
        matrix = new int[n, n];
        int startValue = 1;

        for (int col = 0; col < matrix.GetLength(1); col++)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                matrix[row, col] = startValue++;
            }
        }
        PrintArray(matrix);
    }

    private static void SnakeMoveCols()
    {
        matrix = new int[n, n];

        int startValue = 1;

        for (int col = 0; col < matrix.GetLength(1); col++)
        {
            if ((col & 1) == 0) //index is even!
            {
                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    matrix[row, col] = startValue++;
                }
            }
            else
            {
                int lastRow =  matrix.GetLength(0) - 1;

                for (int row = lastRow; row >= 0; row--)
                {
                    matrix[row, col] = startValue++;
                }
            }
        }
        PrintArray(matrix);
    }

    private static void SnakeMoveDiagonals()
    {
        int[,] matrix = new int[n, n];

        int currentValue = 1;
        int diagonalLength = 1;
        int col = 0;

        int lastRow = matrix.GetLength(0) - 1;
        int lastCol = matrix.GetLength(1) - 1;

        SolveHalf(matrix, ref currentValue, ref diagonalLength, ref col, lastRow, lastCol);//including Longest diagonal

        SolveRest(matrix, ref currentValue, ref diagonalLength);

        PrintArray(matrix);
    }

    private static void SolveRest(int[,] matrix, ref int currentValue, ref int diagonalLength)
    {
        int currentRow = 0;
        int currentCol = 1;

        while (diagonalLength >= 1)
        {
            for (int i = currentCol, j = currentRow; i < matrix.GetLength(1); i++, j++)
            {
                matrix[j, i] = currentValue++;
            }
            diagonalLength--;
            currentCol++;
        }
    }

    private static void SolveHalf(int[,] matrix, ref int currentValue, ref int diagonalLength, ref int col, int lastRow, int lastCol)
    {
        for (int row = lastRow; row >= 0; row--)
        {
            bool hasDiagonal = row != lastRow || diagonalLength > 1;

            if (hasDiagonal)
            {
                diagonalLength++;
                int tempRow = row;

                for (int i = 0; i < diagonalLength; i++)//next step is on diag start
                {
                    matrix[tempRow, col] = currentValue++;
                    tempRow++;
                    col++;
                }
            }
            else // first step in matrix
            {
                matrix[row, col] = currentValue++;
            }

            if (col == lastCol && row == lastRow)
            {
                matrix[row, col] = currentValue++;
                diagonalLength--;
                break; //half matrix is visited
            }
            col = 0;
        }
    }

    private static void Spiral()
    {
        int[,] matrix = new int[n, n];

        int pos = 1;
        int count = n;
        int value = -n;
        int sum = -1;

        do
        {
            value = -1 * value / n;
            for (int i = 0; i < count; i++)
            {
                sum += value;
                //matrix[sum / n, sum % n] = pos++; //steps in matrix clockwise
                matrix[sum % n, sum / n] = pos++;
            }
            value *= n;
            count--;
            for (int i = 0; i < count; i++)
            {
                sum += value;
                //matrix[sum / n, sum % n] = pos++; //steps in matrix clockwise
                matrix[sum % n, sum / n] = pos++;
            }
        } while (count > 0);

        PrintArray(matrix);
    }

    static void Main()
    {
        Console.Write("Input size of matrix: ");
        n = int.Parse(Console.ReadLine());

        EachColTopToBottom();
        Console.WriteLine();

        SnakeMoveCols();
        Console.WriteLine();

        SnakeMoveDiagonals();
        Console.WriteLine();

        Spiral();
    }
}