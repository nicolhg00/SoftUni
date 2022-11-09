using System;
using System.Diagnostics.CodeAnalysis;

namespace Exercise2
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            int sum = 0;
            int max = 0;
            for (int i = 0; i < count; i++)

            {
                int current = int.Parse(Console.ReadLine());
                sum += current;
                if (current > max)
                {
                    max = current;
                }

            }
            if (sum - max == max)
            {
                Console.WriteLine("Yes");
                Console.WriteLine($"Sum = {max}");
            }
            else
            {
                int diff =Math.Abs( max - (sum - max));
                Console.WriteLine("No");
                Console.WriteLine($"Diff = {diff}");
            }
        }
    }
}
