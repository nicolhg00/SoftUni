using System;

namespace Exersice3
{
    class Program
    {
        static void Main(string[] args)
        {
            //входни данни
            //1.наем -> спрямо сезона
            //2. отстъпки -> спрямо брой на хората
            //3. допълнителни отстъпка
            //4. проверка за бюджет

            int budget = int.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            int countFishers = int.Parse(Console.ReadLine());

            double rent = 0;
            switch (season)
            {
                case "Spring":
                    rent = 3000;
                    break;
                case "Summer":
                case "Autumn":
                    rent = 4200;
                    break;
                case "Winter":
                    rent = 2600;
                    break;

                default:
                    break;
            }
            if (countFishers <= 6)
            {
                rent = rent - 0.10 * rent;
            }
            else if (countFishers >= 7 && countFishers <=11)
            {
                rent = rent - 0.15 * rent;
            }
            else if(countFishers >= 12)
            {
                rent = rent - 0.25 * rent;
            }
            if (countFishers % 2 == 0 && season != "Autumn")
            {
                rent = rent - 0.05 * rent;
            }

            if (budget >= rent)
            {
                double leftMoney = budget - rent;
                Console.WriteLine($"Yes! You have {leftMoney:f2} leva left.");
            }
            else
            {
                double needMoney = rent - budget;
                Console.WriteLine($"Not enough money! You need {needMoney:f2} leva.");
            }
        }
    }
}
