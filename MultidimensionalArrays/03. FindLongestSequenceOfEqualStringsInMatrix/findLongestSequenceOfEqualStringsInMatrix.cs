using System;
using System.Text;

internal enum Direction
{
    Horizontal,
    Vertical,
    SlashDiag,
    BackSlashDiag
}

class FindLongestSequenceOfEqualStringsInMatrix
{

    static void Main()
    {
        string[,] matrix = new string[,]
        {
            {"ff", "mm", "mm", "vv"},

            {"gg", "ff", "mm", "vv"},

            {"gg", "mm", "ff", "vv"},

            {"ff", "mm", "vv", "ff"},

            {"gg", "vv", "ff", "vv"},
        };

        int bestRowSeq = 0;
        int bestColSeq = 0;
        int bestLen = 0;
        int currentLen = 0;
        Direction direction = Direction.BackSlashDiag;
      
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                currentLen = CheckRow(matrix, row, col);
                if (currentLen > bestLen)
                {
                    bestLen = currentLen;
                    bestRowSeq = row;
                    bestColSeq = col;
                    direction = Direction.Horizontal;
                }

                currentLen = CheckCol(matrix, row, col);
                if (currentLen > bestLen)
                {
                    bestLen = currentLen;
                    bestRowSeq = row;
                    bestColSeq = col;
                    direction = Direction.Vertical;
                }

                currentLen = CheckBackSlashDiag(matrix, row, col);
                if (currentLen > bestLen)
                {
                    bestLen = currentLen;
                    bestRowSeq = row;
                    bestColSeq = col;
                    direction = Direction.BackSlashDiag;
                }

                currentLen = CheckSlashDiag(matrix, row, col);
                if (currentLen > bestLen)
                {
                    bestLen = currentLen;
                    bestRowSeq = row;
                    bestColSeq = col;
                    direction = Direction.SlashDiag;
                }
            }
        }

        int count = 0;
        StringBuilder sb = new StringBuilder();
        while (count < bestLen)
        {
            sb.Append(matrix[bestRowSeq, bestColSeq] + " ");
            sb.Append(Environment.NewLine);
            count++;
        }
        Console.Write(sb.ToString());
    }

    

    private static int CheckRow(string[,] matrix, int row, int startCol)
    {
        int seqLen = 0;

        for (int col = startCol; col < matrix.GetLength(1); col++)
        {
            if (matrix[row, col] != matrix[row, startCol])
            {
                break;
            }
            seqLen++;
        }
        return seqLen;
    }

    private static int CheckCol(string[,] matrix, int startRow, int col)
    {
        int seqLen = 0;

        for (int row = startRow; row < matrix.GetLength(0); row++)
        {
            if (matrix[row, col] != matrix[startRow, col])
            {
                break;
            }
            seqLen++;
        }
        return seqLen;
    }

    private static int CheckBackSlashDiag(string[,] matrix, int startRow, int startCol)
    {
        int seqLen = 0;

        for (int row = startRow, col = startCol; row < matrix.GetLength(0) && col < matrix.GetLength(1); row++, col++)
        {
            if (matrix[row, col] != matrix[startRow, startCol])
            {
                break;
            }
            seqLen++;
        }
        return seqLen;
    }

    private static int CheckSlashDiag(string[,] matrix, int startRow, int startCol)
    {
        int seqLen = 0;

        for (int row = startRow, col = startCol; row < matrix.GetLength(0) && col >= 0; row++, col--)
        {
            if (matrix[row, col] != matrix[startRow, startCol])
            {
                break;
            }
            seqLen++;
        }
        return seqLen;
    }
}
