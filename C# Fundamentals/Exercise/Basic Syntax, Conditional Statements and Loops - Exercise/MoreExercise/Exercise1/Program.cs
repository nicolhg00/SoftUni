using System;

namespace Exercise1
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string nameGame = Console.ReadLine();
            double priceGame = 0;
            double balance = 0;
            double currentBudget = budget;
            

            while (nameGame != "Game Time")
            { 
                
                
                switch (nameGame)
                {
                    case "OutFall 4":
                        priceGame += 39.99;
                        break;
                    case "CS: OG":
                        priceGame += 15.99;
                        break;
                    case "Zplinter Zell":
                        priceGame += 19.99;
                        break;
                    case "Honored 2":
                        priceGame += 59.99;
                        break;
                    case "RoverWatch":
                        priceGame += 29.99;
                        break;
                    case "RoverWatch Origins Edition":
                        priceGame += 39.99;
                        break;
                    default:
                        Console.WriteLine("Not Found");
                        nameGame = Console.ReadLine();
                        continue;

                }

                balance += priceGame;

                if (currentBudget < priceGame)
                {
                    Console.WriteLine("Too Expensive");
                    priceGame = 0;
                }
               
                else if (currentBudget > 0)
                {
                    Console.WriteLine($"Bought {nameGame}");
                }
                
                if (balance == currentBudget)
                {
                    Console.WriteLine("Out of money!");
                    break;
                }

                currentBudget -= priceGame;
                priceGame = 0;
                nameGame = Console.ReadLine();

            }
            if (currentBudget == 0)
            {
                Console.WriteLine("Out of money!");
            }
            else if (budget > currentBudget)
            {
                Console.WriteLine($"Total spent: ${(balance):f2}. Remaining: ${(currentBudget):f2}");
            }

        }
    }
}
