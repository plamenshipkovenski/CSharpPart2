using System;
using System.Text;
using System.IO;
using System.Security;

class ReadFile
{
    public static string ReadAllText(string path,Encoding encoding)
    {
        string content = string.Empty;

        try
        {
            content = File.ReadAllText(path, encoding);
        }
        catch (ArgumentNullException ane)
        {
            Console.WriteLine(ane.Message);
        }
        catch (ArgumentException ae)
        {
            Console.WriteLine(ae.Message);
        }
        catch (PathTooLongException ptle)
        {
            Console.WriteLine(ptle.Message);
        }
        catch (DirectoryNotFoundException dnfe)
        {
            Console.WriteLine(dnfe.Message);
        }
        catch (FileNotFoundException fnfe)
        {
            Console.WriteLine(fnfe.Message);
        }
        catch (IOException ioe)
        {
            Console.WriteLine(ioe.Message);
        }
        catch (UnauthorizedAccessException uae)
        {
            Console.WriteLine(uae.Message);
        }
        catch (NotSupportedException nse)
        {
            Console.WriteLine(nse.Message);
        }
        catch (SecurityException se)
        {
            Console.WriteLine(se.Message);
        }
        return content;
    }
    static void Main()
    {
        //TO DO cyrilic
        Encoding encoding = Encoding.Default;
        string path = string.Empty;
        Console.WriteLine("input file path:");
        path = Console.ReadLine();

        string content = ReadAllText(path, encoding);
        Console.WriteLine(content);
    }
}