using System;
using System.Collections.Generic;
using System.Linq;

namespace _11.KeyRevolver
{
    class Program
    {
        static void Main(string[] args)
        {
            int priceOfBullet = int.Parse(Console.ReadLine());
            int sizeOfTheBarrel = int.Parse(Console.ReadLine());
            int[] bullets = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int[] locks = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int valueOfIntelligence = int.Parse(Console.ReadLine());

            Stack<int> stackBullet = new Stack<int>(bullets);
            Queue<int> queueLocks = new Queue<int>(locks);

            int count = 0;
            int usedBullet = 0;

            while (stackBullet.Count > 0 && queueLocks.Count > 0)
            {
                if (stackBullet.Peek() <= queueLocks.Peek())
                {
                    Console.WriteLine("Bang!");
                    stackBullet.Pop();
                    queueLocks.Dequeue();

                }
                else
                {
                    Console.WriteLine("Ping!");
                    stackBullet.Pop();
                }
                count++;

                if (count == sizeOfTheBarrel && stackBullet.Count > 0)
                {
                    Console.WriteLine("Reloading!");
                    count = 0;
                }
                usedBullet++;
            }

            if (queueLocks.Count == 0)
            {
                Console.WriteLine($"{stackBullet.Count} bullets left. Earned ${valueOfIntelligence - (usedBullet*priceOfBullet)}");
            }
            else
            {
                Console.WriteLine($"Couldn't get through. Locks left: {queueLocks.Count}");
            }
        }
    }
}
