using System;
using System.Linq;

namespace _2.KnightsOfHonor
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<string> names = n =>
            {
                Console.WriteLine("Sir " + n);
            };
            Console.ReadLine().Split(" ").ToList()
                .ForEach(names);
        }
    }
}
