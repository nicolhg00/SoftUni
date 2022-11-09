using System;

namespace _8._Factorial_Division
{
    class Program
    {
        static void Main(string[] args)
        {
            int first = int.Parse(Console.ReadLine());
            int second = int.Parse(Console.ReadLine());

            double firstFactroial = CalculateFactorial(first);
            double secondFactroial = CalculateFactorial(second);

            double result = firstFactroial  / secondFactroial;

            Console.WriteLine($"{result:f2}");
        }

        private static double CalculateFactorial(int number)
        {
            double factorial = 1;
            for (int i = 2; i <= number; i++)
            {
                factorial *= i;
            }
            return factorial;
        }
    }
}
