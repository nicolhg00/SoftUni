using System;

namespace ExerciseDataTypes
{
    class Program
    {
        static void Main(string[] args)
        {
            int numer1 = int.Parse(Console.ReadLine());
            int numer2 = int.Parse(Console.ReadLine());
            int numer3 = int.Parse(Console.ReadLine());
            int numer4 = int.Parse(Console.ReadLine());

            long result = (numer1 + numer2) / numer3 * numer4;
            Console.WriteLine(result);
        }
    }
}
