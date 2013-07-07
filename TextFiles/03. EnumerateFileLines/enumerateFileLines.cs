using System;
using System.Text;
using System.IO;

class EnumerateFileLines
{
    private static void EnumerateLines(string source, string destination)
    {
        try
        {
            Encoding encoding = Encoding.GetEncoding("UTF-8");

            StreamReader reader = new StreamReader(source, encoding);
            StreamWriter writer = new StreamWriter(destination, false, encoding);

            using (reader)
            {
                using (writer)
                {
                    string line = string.Empty;
                    int lineCount = 1;

                    while ((line = reader.ReadLine()) != null)
                    {
                        StringBuilder lineEnumerated = new StringBuilder();

                        lineEnumerated.Append(lineCount.ToString());
                        lineEnumerated.Append('.');
                        lineEnumerated.Append(' ');
                        lineEnumerated.Append(line);

                        writer.WriteLine(lineEnumerated.ToString());

                        lineCount++;
                    }
                }
            }
        }
        catch (FileNotFoundException)
        {
            Console.Error.WriteLine("Can not find file {0}.", source);
        }
        catch (DirectoryNotFoundException)
        {
            Console.Error.WriteLine("Invalid directory in the file path.");
        }
        catch (IOException)
        {
            Console.Error.WriteLine("Can not open the file {0}", source);
        }
    }

    private static string GetFileName(string fileName)
    {
        return fileName.Substring((fileName.LastIndexOf('\\') + 1));
    }

    static void Main()
    {
        string file1 = @"..\..\test.txt";
        string enumerated = @"..\..\enumerated.txt";

        EnumerateLines(file1, enumerated);

        Console.WriteLine("{0} holds {1} lines enumerated now!", GetFileName(enumerated), GetFileName(file1));
    }
}