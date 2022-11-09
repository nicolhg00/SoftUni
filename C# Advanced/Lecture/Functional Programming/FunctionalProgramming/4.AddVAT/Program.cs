using System;
using System.Linq;

namespace _4.AddVAT
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ReadLine()
                .Split(", ")
                .Select(decimal.Parse)
                .Select(p => p * 1.2M)
                .ToList()
                .ForEach(p => Console.WriteLine($"{p:f2}"));
        }
    }
}
