using System;

namespace exercise2
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            double budget = double.Parse(Console.ReadLine());
            int numOfBottles = int.Parse(Console.ReadLine());
            int numOfChips = int.Parse(Console.ReadLine());

            double priceOfBottles = numOfBottles * 1.20;
            double priceOfChips = Math.Ceiling((priceOfBottles * 0.45) * numOfChips);
            double totalPrice = priceOfBottles + priceOfChips;

            if (budget >= totalPrice)
            {
                Console.WriteLine($"{name} bought a snack and has {budget-totalPrice:f2} leva left.");
            }
            else
            {
                Console.WriteLine($"{name} needs {totalPrice-budget:f2} more leva!");
            }
        }
    }
}
