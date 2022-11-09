﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace _1.Lootbox
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> firstBox = new Queue<int>(Console.ReadLine().Split(" ").Select(int.Parse).ToArray());
            Stack<int> secondBox = new Stack<int>(Console.ReadLine().Split(" ").Select(int.Parse).ToArray());
            int sum = 0;
            while (firstBox.Count != 0 && secondBox.Count != 0)
            {
                int currSum = 0;
                currSum = firstBox.Peek() + secondBox.Peek();

                if (currSum % 2 == 0 )
                {
                    firstBox.Dequeue();
                    secondBox.Pop();
                    sum += currSum;
                }
                else
                {
                    firstBox.Enqueue(secondBox.Peek());
                    secondBox.Pop();
                }
            }

            if (firstBox.Count == 0)
            {
                Console.WriteLine("First lootbox is empty");
            }
            else
            {
                Console.WriteLine("Second lootbox is empty");
            }

            if (sum >= 100)
            {
                Console.WriteLine($"Your loot was epic! Value: {sum}");
            }
            else
            {
                Console.WriteLine($"Your loot was poor... Value: {sum}");
            }
        }
    }
}
