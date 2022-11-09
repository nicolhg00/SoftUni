using System;
using System.Linq;

namespace _2.SumNumbers
{
    class Program
    {

        
        static void Main(string[] args)
        {
            Func<string, int> parser = n => int.Parse(n);

            int[] numbers = Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .ToArray();

            Console.WriteLine(numbers.Length);
            Console.WriteLine(numbers.Sum());
        }

        
    }
}
