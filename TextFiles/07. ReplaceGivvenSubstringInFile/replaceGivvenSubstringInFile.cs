using System;
using System.IO;
using System.Text;

class ReplaceGivvenSubstringInFile
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
                        writer.WriteLine(line.Replace("start", "end"));
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