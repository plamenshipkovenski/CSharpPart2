using System;
using System.IO;
using System.Text;

class TextFilesConcatenation
{

    private static void FinalPrint(string source1, string source2, string destination)
    {
        string fileName = GetFileName(destination);
        Console.WriteLine("union successful");

        Console.WriteLine("{0} keeps {1} and {2} content now!", fileName, GetFileName(source1), GetFileName(source2));
        Console.WriteLine("{0} path:\r\n{1}", fileName, string.Concat(Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory()).ToString()), string.Concat("\\", fileName)));
    }

    private static string GetFileName(string fullName)
    {
        return fullName.Substring((fullName.LastIndexOf('\\') + 1));
    }

    private static void FileConcat(string source, string destination)
    {
        try
        {
            Encoding encoding = Encoding.GetEncoding("UTF-8");

            StreamReader reader = new StreamReader(source, encoding);
            StreamWriter writer = new StreamWriter(destination, true, encoding); // true appends source to destination

            using (reader)
            {
                using (writer)
                {
                    string line = string.Empty;

                    while ((line = reader.ReadLine()) != null)
                    {
                        writer.WriteLine(line);
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

    static void Main()
    {
        string source1 = @"..\..\myFile.txt";
        string source2 = @"..\..\testFile1.txt";
        string destination = @"..\..\concat.txt";

        FileConcat(source1, destination);
        FileConcat(source2, destination);

        FinalPrint(source1, source2, destination);
    }
}