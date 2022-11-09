using System;

namespace Exrecise2
{
    class Program
    {
        static void Main(string[] args)
        {
            int age = int.Parse(Console.ReadLine());
            double priceWashing = double.Parse(Console.ReadLine());
            double priceToy = double.Parse(Console.ReadLine());
            int toyCounter = 0;
            double savedMoney = 0;
            double moneyPresent = 10;
            for (int i = 1; i <= age; i++)
            {
                if (i % 2 ==0)
                {
                    savedMoney += moneyPresent;
                    savedMoney--;
                    moneyPresent += 10;
                }
                else
                {
                    toyCounter++;
                }
            }
            double moneyForToys = toyCounter * priceToy;
            savedMoney += moneyForToys;
            if (savedMoney >= priceWashing)
            {
                Console.WriteLine($"Yes! {savedMoney - priceWashing :f2}");
            }
            else
            {
                Console.WriteLine($"No! {priceWashing - savedMoney :f2}");
            }
        }
    }
}
