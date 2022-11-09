using System;

namespace Exercise5
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget= double.Parse(Console.ReadLine());
            int statistic = int.Parse(Console.ReadLine());
            double decore = double.Parse(Console.ReadLine());

            double totalPriceOfDecore = decore * statistic;

            budget -= 0.10 * budget;

            if (statistic > 150)
            {
                totalPriceOfDecore -= totalPriceOfDecore * 0.10;
            }

            budget -= totalPriceOfDecore;

            if (budget>=0)
            {
                Console.WriteLine("Action!");
                Console.WriteLine($"Wingard starts filming with {budget:f2} leva left.");
            }
            else
            {
                Console.WriteLine("Not enough money!");
                Console.WriteLine($"Wingard needs {Math.Abs(budget):f2} leva more.");
            }
        }
    }
}
