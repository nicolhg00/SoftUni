﻿using System;

namespace Exercise7
{
    class Program
    {
        static void Main(string[] args)
        {
            string line = Console.ReadLine();
            double balance = 0;
            while (line != "Start")
            {
                double currentCoin = double.Parse(line);
                if (currentCoin == 0.1 || currentCoin == 0.2 || currentCoin == 0.5 || currentCoin == 1 || currentCoin == 2)
                {
                    balance += currentCoin;
                }
                else
                {
                    Console.WriteLine($"Cannot accept {currentCoin}");
                }
                line = Console.ReadLine();
            }
            line = Console.ReadLine();
            while (line != "End")
            {
                double productPrice = 0;
                if (line == "Nuts")
                {
                    productPrice = 2;
                }
                else if (line == "Water")
                {
                    productPrice = 0.7;
                }
                else if (line == "Crisps")
                {
                    productPrice = 1.5;
                }
                else if (line == "Soda")
                {
                    productPrice = 0.8;
                }
                else if (line == "Coke")
                {
                    productPrice = 1;
                }

                if (productPrice !=0)
                {
                    if (balance >= productPrice)
                    {
                        Console.WriteLine($"Purchased {line.ToLower()}");
                        balance -= productPrice;
                    }
                    else
                    {
                        Console.WriteLine("Sorry, not enough money");
                    }
                    
                }
                else
                {
                    Console.WriteLine("Invalid product");
                }
                line = Console.ReadLine();
            }
            Console.WriteLine($"Change: {balance:f2}");
        }
    }
}
