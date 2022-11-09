using System;
using System.Collections.Generic;
using System.Linq;

namespace MuOnline
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split("|")
                .ToArray();

            int initialHealth = 100;
            int intitialBitcoint = 0;
            int counter = 0;

            for (int i = 0; i < input.Length; i++)
            {
                string[] currentIndex = input[i]
                    .Split(" ")
                    .ToArray();

                string monster = currentIndex[0];
                string number = currentIndex[1];
                counter++;

                int damage = int.Parse(number);

                if (monster == "potion")
                {
                    int currentHealt = initialHealth;
                    initialHealth += damage;

                    if (initialHealth > 100)
                    {
                        initialHealth = 100;
                    }
                    int healed = initialHealth - currentHealt;

                    Console.WriteLine($"You healed for {healed} hp.");
                    Console.WriteLine($"Current health: {initialHealth} hp.");

                }
                else if (monster == "chest")
                {
                    intitialBitcoint += damage;
                    Console.WriteLine($"You found {damage} bitcoins.");
                }
                else
                {
                    initialHealth -= damage;
                    if (initialHealth <= 0)
                    {
                        Console.WriteLine($"You died! Killed by {monster}.");
                        Console.WriteLine($"Best room: {counter}");
                        break;
                    }
                    else
                    {
                        Console.WriteLine($"You slayed {monster}.");
                    }
                }
            }
            if (initialHealth > 0)
            {
                Console.WriteLine("You've made it!");
                Console.WriteLine($"Bitcoins: {intitialBitcoint}");
                Console.WriteLine($"Health: {initialHealth}");
            }
        }
    }
}
