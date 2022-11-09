using System;
using System.Collections.Generic;
using System.Linq;

namespace _4.FindEvensOrOdds
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                 .Split(" ")
                 .Select(int.Parse)
                 .ToArray();
            string command = Console.ReadLine();

            Predicate<int> predicate = command == "odd"
                ? number => number % 2 != 0
                : new Predicate<int>((number) => number % 2 == 0);

            List<int> result = new List<int>();

            for (int i = numbers[0]; i <= numbers[1]; i++)
            {
                if (predicate(i))
                {
                    result.Add(i);
                }
            }
            Console.WriteLine(String.Join(" ", result));
        }
    }
}
