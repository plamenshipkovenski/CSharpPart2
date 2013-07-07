using System;
using System.IO;
using System.Text;

class CompareTextFiles
{
    private static bool CompareLines(string line1, string line2)
    {
        if (line1.Trim().Equals(line2.Trim()))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private static string GetFileName(string fileName)
    {
        return fileName.Substring((fileName.LastIndexOf('\\') + 1));
    }

    private static void ComparisonPrint(string file1, string file2, int equalLines, int diffLines)
    {
        Console.WriteLine("{0} and {1} has {2} equal lines and {3} different lines!", GetFileName(file1), GetFileName(file2), equalLines, diffLines);
    }

    private static void CompareFiles(string file1, string file2)
    {
        try
        {
            int equalLines = 0;
            int diffLines = 0;

            Encoding encoding = Encoding.GetEncoding("UTF-8");

            StreamReader reader1 = new StreamReader(file1, encoding);
            StreamReader reader2 = new StreamReader(file2, encoding);

            string line1 = string.Empty;
            string line2 = string.Empty;

            using (reader1)
            {
                using (reader2)
                {
                    while ((line1 = reader1.ReadLine()) != null) // assume files have equal number of lines
                    {
                        line2 = reader2.ReadLine();

                        if (!CompareLines(line1, line2))
                        {
                            diffLines++;
                        }
                        else
                        {
                            equalLines++;
                        }
                    }
                }
            }

            ComparisonPrint(file1, file2, equalLines, diffLines);
        }
        catch (FileNotFoundException)
        {
            Console.Error.WriteLine("Can not find file {0}.", file1);
        }
        catch (DirectoryNotFoundException)
        {
            Console.Error.WriteLine("Invalid directory in the file path.");
        }
        catch (IOException)
        {
            Console.Error.WriteLine("Can not open the file {0}", file1);
        }
    }

    static void Main()
    {
        string file1 = @"..\..\file1.txt";
        string file2 = @"..\..\file2.txt";

        CompareFiles(file1, file2);
    }
}