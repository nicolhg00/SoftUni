using System;
using System.Text;

namespace _6.__Replace_Repeating_Chars
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            char prevSymbol = '\0';

            StringBuilder result = new StringBuilder();

            foreach (char letter in text)
            {
                if (letter != prevSymbol)
                {
                    result.Append(letter);
                }
                prevSymbol = letter;
            }

            Console.WriteLine(result);
        }
    }
}
