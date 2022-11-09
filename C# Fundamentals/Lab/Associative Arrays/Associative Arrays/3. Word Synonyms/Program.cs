using System;
using System.Collections.Generic;
using System.Linq;

namespace _3._Word_Synonyms
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine()
                .Split(" ");
            IEnumerable<string> filteredWords = words
                .Where(word => word.Length % 2 == 0);

            foreach (var word in filteredWords)
            {
                Console.WriteLine(word);
            }
        }
    }
}
