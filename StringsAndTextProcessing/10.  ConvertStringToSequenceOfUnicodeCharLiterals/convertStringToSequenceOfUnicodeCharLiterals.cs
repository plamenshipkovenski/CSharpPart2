using System;
using System.IO;

class ConvertStringToSequenceOfUnicodeCharLiterals
{
    static void Main()
    {
        string inputStr = "Hi!";
        StringWriter sw = new StringWriter();

        foreach (var ch in inputStr)
        {
            sw.Write("\\u{0:X4}", (int)ch); 
        }
        Console.WriteLine(sw.ToString());
    }
}