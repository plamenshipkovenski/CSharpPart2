using System;
using System.Text;

class encryptDecrypt
{

    private static string Crypt(string inputStr, string key)
    {
        StringBuilder sb = new StringBuilder();

        for (int i = 0, j = 0; i < inputStr.Length; i++)
        {
            if (inputStr.Length <= key.Length)
            {
                sb.Append((char)(inputStr[i] ^ key[j]));
            }
            else
            {
                if (i % (key.Length) == 0)
                {
                    j = 0;
                }
                else
                {
                    j++;
                }
                sb.Append((char)(inputStr[i] ^ key[j]));
            }
        }
        return sb.ToString();
    }

    static void Main()
    {
        Console.WriteLine("input string");
        string inputStr = Console.ReadLine();

        string key = "-.*9^agFJDKlkshj(*&^%$#@#$%D$%YH6hUIF";

        string encrypted = Crypt(inputStr, key);
        Console.WriteLine(encrypted);

        string decrypted = Crypt(encrypted, key);
        Console.WriteLine(decrypted);
    }
}