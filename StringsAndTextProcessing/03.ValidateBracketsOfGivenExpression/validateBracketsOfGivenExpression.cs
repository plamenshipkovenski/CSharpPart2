using System;

class ValidateBracketsOfGivenExpression
{
    static void Main()
    {
        Console.Title = "validate brackets";
        Console.Write("input expression: ");
        string expression = Console.ReadLine();

        string openingBracket = "(";
        string closingBracket = ")";

        bool isValidExpr = false;

        int firstOpenBrIndex = expression.IndexOf(openingBracket);
        int firstClosingBrIndex = expression.IndexOf(closingBracket);

        bool hasAnyBracket = (0 <= firstOpenBrIndex) || (0 <= firstClosingBrIndex);

        if (hasAnyBracket)
        {
            bool hasOpeningBracketFisrt = firstOpenBrIndex < firstClosingBrIndex;
            bool lastBracketIsClosing = expression.LastIndexOf(openingBracket) < expression.LastIndexOf(closingBracket);

            if (hasOpeningBracketFisrt && lastBracketIsClosing)
            {
                int sum = 0;

                for (int index = expression.IndexOf(openingBracket); index <= expression.LastIndexOf(closingBracket); index++)
                {
                    if (expression[index].Equals(openingBracket)) sum++;

                    if (expression[index].Equals(closingBracket)) sum--;
                }

                if (sum == 0) isValidExpr = true;
            }
        }

        if (isValidExpr)
        {
            Console.WriteLine("this Expression brackets are valid!");
        }
        else
        {
            Console.WriteLine("this Expression brackets are Not valid!");
        }
    }
}