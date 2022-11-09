﻿using System;
using System.Linq;

namespace Heart_Delivery
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] houses = Console.ReadLine()
                .Split("@", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            string command = Console.ReadLine();
            int currentIndex = 0; 

            while (command != "Love!")
            {
                string[] tokens = command
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                currentIndex += int.Parse(tokens[1]);

                if (currentIndex >= houses.Length)
                {
                    currentIndex = 0;
                }

                if (houses[currentIndex]==0)
                {
                    Console.WriteLine($"Place {currentIndex} already had Valentine's day.");
                }
                else
                {
                    houses[currentIndex] -= 2;
                    if (houses[currentIndex] == 0)
                    {
                        Console.WriteLine($"Place {currentIndex} has Valentine's day.");
                    }
                }

                command = Console.ReadLine();
            }

            Console.WriteLine($"Cupid's last position was {currentIndex}.");

            int housesWithoutVD = houses
                .Where(h => h > 0)
                .Count();

            if (housesWithoutVD > 0)
            {
                Console.WriteLine($"Cupid has failed {housesWithoutVD} places.");
            }
            else
            {
                Console.WriteLine($"Mission was successful.");
            }
        }
    }
}
