using System;

namespace Exersice7
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int sum = 0;

            for (int i = 0; i < n; i++)
            {
                int quantites = int.Parse(Console.ReadLine());
                sum += quantites;
                if (sum > 255)
                {
                    Console.WriteLine("Insufficient capacity!");
                    sum -= quantites;
                }


            }
            Console.WriteLine(sum);
        }
    }
}
