using System;
using System.IO;
using System.Text;

class DeleteOddLinesOfTextFile
{
    static void Main()
    {
        string path = @"..\..\myFile.txt";
        string tempFile = Path.GetTempFileName();

        Encoding encoding = Encoding.GetEncoding("utf-8");

        try
        {
            using (var sr = new StreamReader(path, encoding))
            {
                using (var sw = new StreamWriter(tempFile))
                {
                    string line = string.Empty;
                    int lineCount = 1;

                    while ((line = sr.ReadLine()) != null)
                    {
                        bool isEvenLine = (lineCount & 1) == 0;

                        if (isEvenLine)
                        {
                            sw.WriteLine(line);
                        }

                        lineCount++;
                    }
                }
            }

            File.Delete(path);
            File.Move(tempFile, path);
        }
        catch (FileNotFoundException e)
        {
            Console.Error.WriteLine(e.Message);
        }
        catch (DirectoryNotFoundException)
        {
            Console.Error.WriteLine("Invalid directory in the file path.");
        }
        catch (IOException e)
        {
            Console.Error.WriteLine(e.Message);
        }
    }
}