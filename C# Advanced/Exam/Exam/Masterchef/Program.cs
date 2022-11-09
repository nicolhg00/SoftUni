using System;
using System.Collections.Generic;
using System.Linq;

namespace Masterchef
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> ingredients = new Queue<int>(Console.ReadLine().Split(" ").Select(int.Parse).ToArray());
            Stack<int> freshness = new Stack<int>(Console.ReadLine().Split(" ").Select(int.Parse).ToArray());

            Dictionary<string, int> dishes = new Dictionary<string, int>();
            dishes.Add("Dipping sauce", 150);
            dishes.Add("Green salad", 250);
            dishes.Add("Chocolate cake", 300);
            dishes.Add("Lobster", 400);

            Dictionary<i>
        }
    }
}
