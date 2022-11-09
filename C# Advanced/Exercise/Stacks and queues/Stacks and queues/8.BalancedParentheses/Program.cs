using System;
using System.Collections.Generic;

namespace _8.BalancedParentheses
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Stack<char> opernParenthesis = new Stack<char>();

            bool isBalance = true;

            foreach (char symbol in input)
            {
                if (symbol == '(' || symbol == '{' || symbol == '[')
                {
                    opernParenthesis.Push(symbol);
                }
                else
                {
                    if (opernParenthesis.Count ==0)
                    {
                        isBalance = false;
                        break;
                    }

                    char lastSymbol = opernParenthesis.Pop();

                    if (symbol == ')'&& lastSymbol != '(')
                    {
                        isBalance = false;
                        break;
                    }
                    else if (symbol == '}' && lastSymbol != '{')
                    {
                        isBalance = false;
                        break;
                    }
                    else if (symbol == ']' && lastSymbol != '[')
                    {
                        isBalance = false;
                        break;
                    }

                }
            }
            if (isBalance)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }
    }
}
