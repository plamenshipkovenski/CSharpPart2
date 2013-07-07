using System;
using System.IO;
using System.Text;


class ExtractProtocolServerResourceElementsFromURL
{

    private static string GetResourcePart(string url)
    {
        StringBuilder sb = new StringBuilder();
        int start = url.IndexOf("/", url.IndexOf("//") + 2);

        for (int index = start; index < url.Length; index++)
        {
            sb.Append(url[index]);
        }
        return sb.ToString();
    }

    private static string GetServerPart(string url)
    {
        StringBuilder sb = new StringBuilder();
        int start = url.IndexOf("//") + 2;
        int end = url.IndexOf("/", start);

        for (int index = start; index < end; index++)
        {
            sb.Append(url[index]);
        }
        return sb.ToString();
    }

    private static string GetProtocolPart(string url)
    {
        StringBuilder sb = new StringBuilder();

        for (int index = 0; index < url.IndexOf("//"); index++)
        {
            sb.Append(url[index]);
        }
        return sb.ToString();
    }

    static void Main()
    {
        //string urlStr = "http://www.devbg.org/forum/index.php";
        Console.WriteLine("input url:");
        string urlStr = Console.ReadLine();
        StringWriter sw = new StringWriter();

        sw.WriteLine("[protocol] = {0}", GetProtocolPart(urlStr));
        sw.WriteLine("[server] = {0}", GetServerPart(urlStr));
        sw.Write("[resource] = {0}", GetResourcePart(urlStr));

        Console.WriteLine(sw.ToString());
    }
}