using System;
using System.Collections.Generic;
using System.Linq;

namespace _4.FastFood
{
    class Program
    {
        static void Main(string[] args)
        {
            int quantity = int.Parse(Console.ReadLine());
            int[] orders = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Queue<int> queueOrders = new Queue<int>(orders);

            Console.WriteLine(queueOrders.Max());

            int sum = 0;
            while (queueOrders.Count > 0)
            {
                int firstInLine = queueOrders.Peek();
                sum += firstInLine;
                if (sum <= quantity)
                {
                    queueOrders.Dequeue();
                }
                else
                {
                    Console.WriteLine($"Orders left: {string.Join(", ",queueOrders)}");
                    return;
                }
            }
            Console.WriteLine("Orders complete");
        }
    }
}
