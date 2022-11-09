using System;
using System.Collections.Generic;
using System.Linq;

namespace _12.CupsAndBottles
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] cups = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int[] bottles = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Stack<int> stackBottles = new Stack<int>(bottles);
            Queue<int> queueCups = new Queue<int>(cups);

            
            int countOfWastedWater = 0;

            while (stackBottles.Count > 0 && queueCups.Count > 0)
            {
                
                if (queueCups.Peek() <= stackBottles.Peek())
                {
                    countOfWastedWater += stackBottles.Peek() - queueCups.Peek();
                    queueCups.Dequeue();
                    stackBottles.Pop();
                    

                }
                else if (stackBottles.Peek() <= queueCups.Peek())
                {
                    int remind = queueCups.Peek() - stackBottles.Peek();
                    queueCups.Dequeue();
                    queueCups.Enqueue(remind);
                    stackBottles.Pop();
                }
            }
            if (queueCups.Count == 0)
            {
                Console.WriteLine($"Bottles: {string.Join(' ',stackBottles)}");
            }
            else
            {
                Console.WriteLine($"Cups: {string.Join(' ', queueCups)}");
            }
            Console.WriteLine($"Wasted litters of water: {countOfWastedWater}");
        }
    }
}
