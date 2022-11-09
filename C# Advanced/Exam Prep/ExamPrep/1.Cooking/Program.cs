using System;
using System.Collections.Generic;
using System.Linq;

namespace _1.Cooking
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> liquid = new Queue<int>(Console.ReadLine().Split(" ").Select(int.Parse).ToArray());
            Stack<int> ingredient = new Stack<int>(Console.ReadLine().Split(" ").Select(int.Parse).ToArray());

            int bread = 25;
            int cake = 50;
            int pastry = 75;
            int fruitPie = 100;

            int countBread = 0;
            int countCake = 0;
            int countPastry = 0;
            int countFruitePie = 0;

            while (liquid.Count != 0 && ingredient.Count != 0)
            {
                int sum = liquid.Peek() + ingredient.Peek();
                if (sum == bread)
                {
                    countBread++;
                    liquid.Dequeue();
                    ingredient.Pop();
                }
                else if (sum == cake)
                {
                    countCake++;
                    liquid.Dequeue();
                    ingredient.Pop();
                }
                else if (sum == pastry)
                {
                    countPastry++;
                    liquid.Dequeue();
                    ingredient.Pop();
                }
                else if (sum == fruitPie)
                {
                    countFruitePie++;
                    liquid.Dequeue();
                    ingredient.Pop();
                }
                else
                {
                    liquid.Dequeue();
                    ingredient.Push(ingredient.Pop() + 3);
                }
            }

            if (countFruitePie > 0 || countPastry > 0)
            {
                if (countCake > 0 || countBread > 0)
                {
                    Console.WriteLine("Wohoo! You succeeded in cooking all the food!");

                }
            }
            else
            {
                Console.WriteLine("Ugh, what a pity! You didn't have enough materials to cook everything.");
            }

            if (liquid.Count > 0)
            {
                Console.Write("Liquids left: ");
                Console.WriteLine(string.Join(", ", liquid));
            }
            else
            {
                Console.WriteLine("Liquids left: none");
            }

            if (ingredient.Count > 0)
            {
                Console.Write("Ingredients left: ");
                Console.WriteLine(string.Join(", ", ingredient));
            }
            else
            {
                Console.WriteLine("Ingredients left: none");
            }

            Console.WriteLine($"Bread: {countBread}");
            Console.WriteLine($"Cake: {countCake}");
            Console.WriteLine($"Fruit Pie: {countFruitePie}");
            Console.WriteLine($"Pastry: {countPastry}");
        }
    }
}
