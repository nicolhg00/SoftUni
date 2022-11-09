using System;
using System.Collections.Generic;
using System.Linq;

namespace WarmWinter
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> hats = new Stack<int>(Console.ReadLine().Split(" ").Select(int.Parse).ToArray());
            Queue<int> scarfs = new Queue<int>(Console.ReadLine().Split(" ").Select(int.Parse).ToArray());

            List<int> sets = new List<int>();
            int maxPriceSet = 0;

            while (hats.Count != 0 && scarfs.Count != 0)
            {
                int priceSet = 0;
                if (scarfs.Peek() > hats.Peek())
                {
                    hats.Pop();
                }
                else if (hats.Peek() > scarfs.Peek())
                {
                    priceSet = hats.Peek() + scarfs.Peek();
                    sets.Add(priceSet);
                    hats.Pop();
                    scarfs.Dequeue();
                    if (priceSet > maxPriceSet)
                    {
                        maxPriceSet = priceSet;
                    }
                }
                else if (hats.Peek() == scarfs.Peek())
                {
                    scarfs.Dequeue();
                    int currHat = hats.Peek();
                    hats.Pop();
                    hats.Push(currHat + 1);
                }
            }
            Console.WriteLine($"The most expensive set is: {maxPriceSet}");

            Console.WriteLine(string.Join(" ", sets));
        }
    }
}
