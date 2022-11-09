using System;

namespace Problem1
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int students = int.Parse(Console.ReadLine());
            double priceOfFlour = double.Parse(Console.ReadLine());
            double priceOfEgg = double.Parse(Console.ReadLine());
            double priceOfApron = double.Parse(Console.ReadLine());

            double neededMoneyForApron = priceOfApron * (Math.Ceiling(students+students*0.2));
            double neededMoneyForEggs = priceOfEgg * 10 * students;
            double neededFlour = students;

            for (int i = 5; i <= students; i++)
            {
                if (i % 5 == 0)
                {
                    neededFlour--;
                }
            }


            double neededMoneyForFlour = priceOfFlour * neededFlour;
            double neededMoney = neededMoneyForApron + neededMoneyForEggs + neededMoneyForFlour;
            if (neededMoney <= budget)
            {
                Console.WriteLine($"Items purchased for {neededMoney:f2}$.");
            }
            else
            {
                Console.WriteLine($"{(neededMoney - budget):f2}$ more needed.");
            }

        }
    }
}
