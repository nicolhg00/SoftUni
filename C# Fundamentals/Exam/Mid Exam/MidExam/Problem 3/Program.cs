using System;
using System.Linq;

namespace Problem_3
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] priceRatings = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToArray();

            int entryPoint = int.Parse(Console.ReadLine());
            string itemsType = Console.ReadLine();
            int leftSum = 0;
            int rightSum = 0;
            for (int i = 0; i < entryPoint; i++)
            {
                if (itemsType == "cheap")
                {
                    if (priceRatings[i] < priceRatings[entryPoint])
                    {
                        leftSum += priceRatings[i];
                    }
                    else
                    {
                        leftSum += 0;
                    }
                }
                else
                {
                    if (priceRatings[i] >= priceRatings[entryPoint])
                    {
                        leftSum += priceRatings[i];
                    }
                    else
                    {
                        leftSum += 0;
                    }
                }
            }

            for (int i = priceRatings.Length - 1; i > entryPoint; i--)
            {
                if (itemsType == "cheap")
                {
                    if (priceRatings[i] < priceRatings[entryPoint])
                    {
                        rightSum += priceRatings[i];
                    }
                    else
                    {
                        rightSum += 0;
                    }
                }
                else
                {
                    if (priceRatings[i] >= priceRatings[entryPoint])
                    {
                        rightSum += priceRatings[i];
                    }
                    else
                    {
                        rightSum += 0;
                    }
                }
            }

            if (leftSum >= rightSum)
            {
                Console.WriteLine("Left - " + leftSum);
            }
            else
            {
                Console.WriteLine("Right - " + rightSum);
            }
        }
    }
}
