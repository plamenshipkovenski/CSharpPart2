using System;
using System.IO;
using System.Text;

class ReadAndPrintOddLinesOfTextFile
{

    private static void PrintOddLines(string fileName)
    {
        try
        {
            Encoding encoding = Encoding.GetEncoding("UTF-8");

            StreamReader reader = new StreamReader(fileName, encoding);

            using (reader)
            {
                string line = string.Empty;
                int lineCount = 1;

                while ((line = reader.ReadLine()) != null)
                {
                    bool isOddLine = (lineCount & 1) == 1;

                    if (isOddLine) Console.WriteLine(line);
                    lineCount++;
                }
            }
        }
        catch (FileNotFoundException)
        {
            Console.Error.WriteLine("Can not find file {0}.", fileName);
        }
        catch (DirectoryNotFoundException)
        {
            Console.Error.WriteLine("Invalid directory in the file path.");
        }
        catch (IOException)
        {
            Console.Error.WriteLine("Can not open the file {0}", fileName);
        }
    }

    static void Main()
    {
        string fileName = @"..\..\myFile.txt"; // located at project folder

        PrintOddLines(fileName);
    }
}