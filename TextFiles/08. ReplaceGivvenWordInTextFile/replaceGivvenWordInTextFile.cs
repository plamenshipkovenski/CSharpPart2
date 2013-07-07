using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;


class ReplaceGivvenWordInTextFile
{
    static void Main()
    {
        string myFile = @"..\..\test1.txt";
        string newFile = @"..\..\test2.txt";

        try
        {
            Encoding encoding = Encoding.GetEncoding("windows-1251");

            using (StreamReader reader = new StreamReader(myFile, encoding))
            {
                using (StreamWriter writer = new StreamWriter(newFile, false, encoding))
                {
                    while (!reader.EndOfStream)
                    {
                        string line = reader.ReadLine();
                        writer.WriteLine(Regex.Replace(line, @"\bstart\b", "end"));
                    }
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}