using System;

namespace Exercise2
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int sum = 0;

            while (number > 0)
            {
                int lastNumber = number % 10;
                sum += lastNumber;

                number /= 10;
            }
            Console.WriteLine(sum);
        }
    }
}
