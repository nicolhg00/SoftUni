using System;

namespace Exercise7
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            int oddSum = 0;
            int evenSum = 0;
            
            for (int i = 0; i < num; i++)
            {
                int n = int.Parse(Console.ReadLine());
                if (i % 2 == 0)
                {
                    evenSum += n;
                }
                else
                {
                    oddSum += n;
                }
            }
            if (evenSum == oddSum)
            {
                Console.WriteLine($"Yes");
                Console.WriteLine($"Sum = {evenSum}");
            }
            else
            {
                int diff = Math.Abs(evenSum - oddSum);
                Console.WriteLine("No");
                Console.WriteLine($"Diff = {diff}");
            }
        }
    }
}
