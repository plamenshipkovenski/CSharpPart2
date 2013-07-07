using System;
using System.Text;

    //enum Mode 
    //{
    //     Text,
    //     OpenTag,
    //   InTag,
    //    CloseTag,
       
    //}

class changeTextBetweenTags
{

    //private static Mode GetCurrentMode(Mode currentMode, char currentChar)
    //{
    //    if (currentChar == '<' && currentMode.)
    //    {
    //        currentMode = Mode.InTag;
    //    }


    //    return currentMode;
    //}

    static void Main()
    {
        string textInput = "We are living in a <upcase>yellow submarine</upcase>. We don't have <upcase>anything</upcase> else.";

        string openTag = "<upcase>";
        string closeTag = "</upcase>";

        bool inText = true;
        bool inOpenTag = false;
        bool inBetweenTags = false;
        bool inCloseTag = false;


        StringBuilder sb = new StringBuilder();

        for (int i = 0; i < textInput.Length; i++)
        {
            char currentChar = textInput[i];

            if (inText)
            {
                if (currentChar == '<')
                {

                    inOpenTag = true;
                    inText = false;
                }
                else
                {
                    sb.Append(currentChar);
                }
            }
            else if (inOpenTag)
            {
                if (currentChar == '>')
                {
                    inBetweenTags = true;
                    inOpenTag = false;
                }
            }
            else if (inBetweenTags)
            {
                if (currentChar == '<')
                {
                    inBetweenTags = false;
                    if (textInput[i + 1] == '/')
                    {
                        inCloseTag = true;
                    }
                    else
                    {
                        inOpenTag = true;
                    }
                }
                else
                {
                    sb.Append(currentChar.ToString().ToUpper());
                }
            }
            else //if (inCloseTag)
            {
                if (currentChar == '>')
                {
                    inCloseTag = false;
                    inText = true;
                }
            }
        }

        Console.WriteLine(sb.ToString());
    }
}