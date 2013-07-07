using System;
using System.Net;
using System.IO;

class DownloadFileFromInternet
{

    private static void DownloadFile(string adress, string fileName, string fullPath)
    {
        using (WebClient client = new WebClient())
        {
            try
            {
                client.DownloadFile(adress, fullPath);

                Console.WriteLine("download complete for:  {0}", fileName);
                Console.WriteLine("file location: {0}", fullPath);
            }
            catch (ArgumentNullException ane)
            {
                Console.WriteLine(ane.Message);
            }
            catch (WebException we)
            {
                Console.WriteLine(we.Message);
            }
            catch (NotSupportedException nse)
            {
                Console.WriteLine(nse.Message);
            }
        }
    }

    private static string GetCurrentDirectory()
    {
        string appPath = Directory.GetCurrentDirectory();

        if (appPath[appPath.Length - 1] != '\\')
        {
            appPath += "\\";
        }
        return appPath;
    }

    static void Main()
    {

        string adress = "http://www.devbg.org/img/Logo-BASD.jpg";

        string fileName = Path.GetFileName(adress); 

        string appPath = GetCurrentDirectory();

        string fullPath = string.Concat(appPath, fileName);

        DownloadFile(adress, fileName, fullPath);
    }
}