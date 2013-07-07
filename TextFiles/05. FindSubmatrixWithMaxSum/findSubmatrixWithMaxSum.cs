using System;
using System.IO;
using System.Text;

class FindSubmatrixWithMaxSum
{
    //Write a program that reads a text file 
    //containing a square matrix of numbers and finds in
    //the matrix an area of size 2 x 2 with a maximal sum of its elements.
    //The first line in the input file contains the size of matrix N.
    //Each of the next N lines contain N numbers separated by space.
    //The output should be a single number in a separate text file

    private static int[,] matrix;

    static void Main()
    {
        string dataFile = @"..\..\arrData.txt";

        ReadFile(dataFile);

        int subMatrLen = 2;
        int maxSum = FindMaxSum(subMatrLen);

        string resultFile = @"..\..\maxSum.txt";
        WriteFile(resultFile, maxSum);

        Console.WriteLine("Done!");
    }

    private static void WriteFile(string path, int maxSum)
    {
        try
        {
            Encoding encoding = Encoding.GetEncoding("utf-8");
            StreamWriter writer = new StreamWriter(path, false, encoding);

            using (writer)
            {
                writer.WriteLine(maxSum);
            }
        }
        catch (UnauthorizedAccessException uae)
        {
            Console.WriteLine(uae.Message);
        }
        catch (ArgumentException ae)
        {
            Console.WriteLine(ae.Message);
        }
        catch (DirectoryNotFoundException dnfe)
        {
            Console.WriteLine(dnfe.Message);
        }
        catch (IOException io)
        {
            Console.WriteLine(io.Message);
        }
    }

    private static int GetSubmatrSum(int matrRow, int matrCol, int subMatrLen)
    {
        int sum = 0;

        for (int row = matrRow; row < matrRow + subMatrLen; row++)
        {
            for (int col = matrCol; col < matrCol + subMatrLen; col++)
            {
                sum += matrix[row, col];
            }
        }
        return sum;
    }

    private static int FindMaxSum(int subMatrLen)
    {
        int sum = 0;
        int maxSum = int.MinValue;

        for (int row = 0; row <= matrix.GetLength(0) - subMatrLen; row++)
        {
            for (int col = 0; col <= matrix.GetLength(1) - subMatrLen; col++)
            {
                sum = GetSubmatrSum(row, col, subMatrLen);

                if (sum > maxSum)
                {
                    maxSum = sum;
                }
            }
        }
        return maxSum;
    }

    private static void ReadFile(string dataFile)
    {

        try
        {
            Encoding encoding = Encoding.GetEncoding("utf-8");
            StreamReader reader = new StreamReader(dataFile, encoding);
            int arrLen = new int();

            using (reader)
            {
                string line = string.Empty;
                bool hasReadLen = false;
                int lineCount = 0;

                while ((line = reader.ReadLine()) != null)
                {
                    if (!hasReadLen)
                    {
                        arrLen = int.Parse(line);
                        matrix = new int[arrLen, arrLen];
                        hasReadLen = true;
                        continue;
                    }

                    FillArrRow(matrix, line, ref lineCount);

                    lineCount++;
                }
            }
        }
        catch (FileNotFoundException)
        {
            Console.Error.WriteLine("Can not find file {0}.", dataFile);
        }
        catch (DirectoryNotFoundException)
        {
            Console.Error.WriteLine("Invalid directory in the file path.");
        }
        catch (IOException)
        {
            Console.Error.WriteLine("Can not open the file {0}", dataFile);
        }
    }

    private static void FillArrRow(int[,] arr, string line, ref int lineCount)
    {
        string[] numHolder = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        for (int col = 0; col < numHolder.Length; col++)
        {
            arr[lineCount, col] = int.Parse(numHolder[col].Trim());
        }
    }
}