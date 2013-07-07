using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

class SortTextFile
{
    //Write a program that reads a text file containing a list of strings, sorts them and saves them to another text file

    private static void WriteFile(string path, List<string> myList)
    {
        try
        {
            Encoding encoding = Encoding.GetEncoding("utf-8");
            StreamWriter writer = new StreamWriter(path, false, encoding);

            using (writer)
            {
                foreach (var str in myList)
                {
                    writer.WriteLine(str);
                }
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

    private static void ReadFile(string unsortedFile, List<string> namesList)
    {
        try
        {
            Encoding encoding = Encoding.GetEncoding("utf-8");
            StreamReader reader = new StreamReader(unsortedFile, encoding);

            using (reader)
            {
                string line = string.Empty;

                while ((line = reader.ReadLine()) != null)
                {
                    namesList.Add(line.Trim());
                }
            }
        }
        catch (FileNotFoundException)
        {
            Console.Error.WriteLine("Can not find file {0}.", unsortedFile);
        }
        catch (DirectoryNotFoundException)
        {
            Console.Error.WriteLine("Invalid directory in the file path.");
        }
        catch (IOException)
        {
            Console.Error.WriteLine("Can not open the file {0}", unsortedFile);
        }
    }

    static void Main()
    {
        string unsortedFile = @"..\..\namesList.txt";
        string sortedFile = @"..\..\sorted.txt";

        List<string> namesList = new List<string>();

        ReadFile(unsortedFile, namesList);
        namesList.Sort();

        WriteFile(sortedFile, namesList);

        Console.WriteLine("{0} keeps {1} in alphabetic order now!", Path.GetFileName(sortedFile), Path.GetFileName(unsortedFile));
    }
}