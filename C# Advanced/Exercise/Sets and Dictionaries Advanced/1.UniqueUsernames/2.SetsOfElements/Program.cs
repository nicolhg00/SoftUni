using System;
using System.Collections.Generic;
using System.Linq;

namespace _2.SetsOfElements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] lengh = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            HashSet<int> firstSet = new HashSet<int>();
            HashSet<int> secondSet = new HashSet<int>();

            for (int i = 0; i < lengh[0]; i++)
            {
                int n = int.Parse(Console.ReadLine());
                firstSet.Add(n);
            }

            for (int i = 0; i < lengh[1]; i++)
            {
                int m = int.Parse(Console.ReadLine());
                secondSet.Add(m);
            }

            foreach (var number in firstSet)
            {
                foreach (var snum in secondSet)
                {
                    if (number == snum)
                    {
                        Console.Write(number + " ");
                    }
                }
            }
        }
    }
}
