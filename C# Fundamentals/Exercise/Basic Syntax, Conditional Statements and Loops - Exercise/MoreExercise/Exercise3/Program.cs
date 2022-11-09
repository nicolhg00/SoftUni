using System;
using System.Linq;

namespace Exercise3
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string newInput = string.Concat(input.Reverse());

            Console.WriteLine(newInput);
        }
    }
}
