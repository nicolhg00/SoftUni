using System;
using System.Linq;

namespace _3.CustomMinFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<int[], int> minNumbers = n => n.Min();
            int[] numbers = Console.ReadLine().Split().Select(int.Parse)
                .ToArray();
            Console.WriteLine(minNumbers(numbers));
        }
    }
}
