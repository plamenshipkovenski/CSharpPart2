using System;
using System.Text;

class ExtractSentencesContainingGivenWord
{
    static void Main()
    {
        string text = " We are living in a yellow submarine. We don't inhave anything else. Inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days.";
        string keyWord = "in";

        StringBuilder sb = new StringBuilder();
        StringBuilder currentSentence = new StringBuilder();
        StringBuilder currentWord = new StringBuilder();

        bool hasMatchKeyword = false;
        bool onWord = true;

        for (int index = 0; index < text.Length; index++)
        {
            char currentChar = text[index];

            bool hasFullSentence = currentChar == '.';
            bool hasInterval = !char.IsLetterOrDigit(currentChar) && currentChar != '.' && currentChar != '\'';

            if (hasFullSentence)
            {

                if (hasMatchKeyword)
                {
                    currentSentence.Append(currentWord);
                    currentSentence.Append('.');
                    sb.Append(currentSentence);
                    hasMatchKeyword = false;
                }
                currentSentence.Clear();
                currentWord.Clear();
            }
            else
            {
                if (hasInterval)
                {

                    if (currentWord.ToString().Equals(keyWord))
                    {
                        hasMatchKeyword = true;
                    }

                    currentSentence.Append(currentWord);
                    currentSentence.Append(' ');
                    onWord = true;
                    currentWord.Clear();
                }
                else if (onWord)
                {
                    currentWord.Append(currentChar);
                }
            }

        }
        Console.WriteLine(sb.ToString().Trim());
    }
}