using System;

namespace exercise1
{
    class Program
    {
        static void Main(string[] args)
        {
            string typeFlowers = Console.ReadLine();
            int countFlowers = int.Parse(Console.ReadLine());
            int budget = int.Parse(Console.ReadLine());
            double pricePerFlower = 0;

            switch (typeFlowers)
            {
                case "Roses":
                    pricePerFlower = 5;
                    break;
                case "Dahlias":
                    pricePerFlower = 3.80;
                    break;
                case "Tulips":
                    pricePerFlower = 2.80;
                    break;
                case "Narcissus":
                    pricePerFlower = 3;
                    break;
                case "Gladiolus":
                    pricePerFlower = 2.50;
                    break;
                default:
                    break;
            }
            double totalPrice = countFlowers * pricePerFlower;
            if (countFlowers >80 && typeFlowers == "Roses")
            {
                totalPrice = totalPrice - 0.10 * totalPrice;
                //totalPrice = 0.9 * totalPrice
            }
            else if (countFlowers > 90 && typeFlowers == "Dahlias")
            {
                totalPrice = totalPrice - 0.15 * totalPrice;
                //totalPrice = 0.85 * totalPrice
            }
            else if (countFlowers > 80 && typeFlowers == "Tulips")
            {
                totalPrice = totalPrice - 0.15 * totalPrice;
            }
            else if (countFlowers < 120  && typeFlowers == "Narcissus")
            {
                totalPrice = totalPrice + 0.20 * totalPrice;
                //totalPrice = 1.2 * totalPrice
            }
            else if (countFlowers < 80 && typeFlowers == "Gladiolus")
            {
                totalPrice = totalPrice + 0.20 * totalPrice;
            }

            if (budget >= totalPrice)
            {
                

                Console.WriteLine($"Hey, you have a great garden with {countFlowers} {typeFlowers} and {budget - totalPrice :F2} leva left.");
            }
            else
            {
                Console.WriteLine($"Not enough money, you need {totalPrice - budget :F2} leva more.");
            }
        }
    }
}
