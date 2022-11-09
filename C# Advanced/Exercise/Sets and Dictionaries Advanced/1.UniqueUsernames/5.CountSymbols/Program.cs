using System;
using System.Collections.Generic;

namespace _5.CountSymbols
{
    class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();
            SortedDictionary<char, int> input = new SortedDictionary<char, int>();

            foreach (char element in word)
            {
                if (!input.ContainsKey(element))
                {
                    input.Add(element, 0);
                }
                input[element]++;
            }

            foreach (var kvp in input)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value} time/s");
            }
        }
    }
}
