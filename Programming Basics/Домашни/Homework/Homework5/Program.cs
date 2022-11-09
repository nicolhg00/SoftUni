using System;
using System.Diagnostics.CodeAnalysis;

namespace Homework5
{
    class Program
    {
        static void Main(string[] args)
        {
            double excursion = double.Parse(Console.ReadLine());
            int puzzles = int.Parse(Console.ReadLine());
            int dolls = int.Parse(Console.ReadLine());
            int bears = int.Parse(Console.ReadLine());
            int minions = int.Parse(Console.ReadLine());
            int trucks = int.Parse(Console.ReadLine());
            int totalToys = puzzles + dolls + bears + minions + trucks;

            double totalMoney = puzzles * 2.6 + dolls * 3 + bears * 4.1 + minions * 8.2 + trucks * 2;
            if (totalToys >= 50)
            {
                totalMoney = totalMoney * 0.75;
            }

            double totalMoneyAfterRent = totalMoney * 0.9;

            if (totalMoneyAfterRent >= excursion)
            {
                double moneyLeft = totalMoneyAfterRent - excursion;
                Console.WriteLine("Yes! {0:F2} lv left.", moneyLeft);
            }
            else if (totalMoneyAfterRent <= excursion)
            {
                double moneyNeeded = excursion - totalMoneyAfterRent;
                Console.WriteLine("Not enough money! {0:F2} lv needed.", moneyNeeded);
            }
        }
    }
}