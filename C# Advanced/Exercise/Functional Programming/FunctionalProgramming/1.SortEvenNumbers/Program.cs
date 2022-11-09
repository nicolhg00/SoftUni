using System;
using System.Linq;

namespace _1.SortEvenNumbers
{
    class Program
    {
        static void Main(string[] args)
        {

            Action<string> name = (n) =>
            {
                Console.WriteLine(n);
            };

            Console.ReadLine().Split(" ").ToList().ForEach(name);
        }
    }
}
