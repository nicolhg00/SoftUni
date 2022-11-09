using System;
using System.Linq;

namespace ArraysLab
{
    class Program
    {
        static void Main(string[] args)
        {
            //1.
            int[] arr = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            //2. foreach , read only
            foreach (var item in arr)
            {
                Console.Write($"{item} ");
            }
        }
    }
}
