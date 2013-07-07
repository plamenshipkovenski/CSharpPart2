using System;
using System.Collections;
using System.Text;

class ReverseWordsInSentence
{
    static void Main()
    {
        string sentence = "C# is not C++, not PHP and not Delphi!";

        Queue nonWordsQueue = new Queue();
        Stack wordsStack = new Stack();
        StringBuilder wordSB = new StringBuilder();
        StringBuilder nonWordSB = new StringBuilder();

        for (int index = 0; index < sentence.Length; index++)
        {
            char currentChar = sentence[index];

            if (char.IsLetter(currentChar) || currentChar == '#' || currentChar == '+')
            {
                wordSB.Append(currentChar);
                if (!string.IsNullOrEmpty(nonWordSB.ToString())) nonWordsQueue.Enqueue(nonWordSB.ToString()); 
                nonWordSB.Clear();
            }
            else
            {
                nonWordSB.Append(currentChar);
                if (!string.IsNullOrEmpty(wordSB.ToString())) wordsStack.Push(wordSB.ToString().Trim());
                wordSB.Clear();
            }
        }

        if (!string.IsNullOrEmpty(nonWordSB.ToString())) nonWordsQueue.Enqueue(nonWordSB.ToString());

        if (!string.IsNullOrEmpty(wordSB.ToString())) wordsStack.Push(wordSB.ToString());

        StringBuilder sentenceSb = new StringBuilder();

        int wordsCount = wordsStack.Count;
        int nonWordsCount = nonWordsQueue.Count;

        int bigger = 0;
        int smaller = 0;

        if (wordsCount > nonWordsCount)
        {
            bigger = wordsCount;
            smaller = nonWordsCount;
        }
        else
        {
            bigger = nonWordsCount;
            smaller = wordsCount;
        }

        for (int i = 0; i < (smaller << 1); i++)
        {
            if ((i & 1) == 0)
            {
                sentenceSb.Append(wordsStack.Pop().ToString());
            }
            else
            {
                sentenceSb.Append(nonWordsQueue.Dequeue().ToString());
            }
        }

        if (wordsStack.Count != 0) sentenceSb.Append(wordsStack.Pop().ToString());

        if (nonWordsQueue.Count != 0) sentenceSb.Append(nonWordsQueue.Dequeue().ToString());

        Console.WriteLine(sentenceSb.ToString());
    }
}