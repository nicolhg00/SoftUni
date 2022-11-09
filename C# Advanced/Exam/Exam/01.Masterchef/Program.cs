using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Masterchef
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Queue<int> ingredients = new Queue<int>(Console.ReadLine().Split(" ").Select(int.Parse).ToArray());
            Stack<int> freshness = new Stack<int>(Console.ReadLine().Split(" ").Select(int.Parse).ToArray());
            

            int dippingSauce = 0;
            int greenSalad = 0;
            int chocolateCake = 0;
            int lobster = 0;

            while (ingredients.Count > 0 && freshness.Count > 0)
            {

                if (ingredients.Peek() == 0)
                {
                    ingredients.Dequeue();
                    continue;
                }
                
                int sum = ingredients.Peek() * freshness.Peek();
                int currIngredient = ingredients.Peek();

                switch (sum)
                {
                    case 150:
                        dippingSauce++;
                        ingredients.Dequeue();
                        freshness.Pop();
                       
                        break;

                    case 250:
                        greenSalad++;
                        ingredients.Dequeue();
                        freshness.Pop();
                        
                        break;

                    case 300:
                        chocolateCake++;
                        ingredients.Dequeue();
                        freshness.Pop();
                        break;

                    case 400:
                        lobster++;
                        ingredients.Dequeue();
                        freshness.Pop();
                        break;

                    default:
                        freshness.Pop();
                        currIngredient += 5;
                        ingredients.Dequeue();
                        ingredients.Enqueue(currIngredient);
                        break;
                }
                

            }

            bool isSuccess = dippingSauce >=1 && greenSalad >= 1 && chocolateCake >= 1 && lobster >= 1;
            if (isSuccess)
            {
                Console.WriteLine("Applause! The judges are fascinated by your dishes!");

            }
            else
            {
                Console.WriteLine("You were voted off. Better luck next year.");
            }

            if (ingredients.Count > 0)
            {
                Console.WriteLine($"Ingredients left: {ingredients.Sum()}");
            }

            if (chocolateCake > 0)
            {
                Console.WriteLine($"# Chocolate cake --> {chocolateCake}");
            }
            if (dippingSauce > 0)
            {
                Console.WriteLine($"# Dipping sauce --> {dippingSauce}");
            }
            if (greenSalad > 0)
            {
                Console.WriteLine($"# Green salad --> {greenSalad}");
            }
            if (lobster > 0)
            {
                Console.WriteLine($"# Lobster --> {lobster}");
            }
        }
    }
}
