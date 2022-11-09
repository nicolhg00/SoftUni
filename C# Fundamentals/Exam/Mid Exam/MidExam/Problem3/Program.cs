using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Problem3
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> priceRating = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            int entryPoint = int.Parse(Console.ReadLine());
            string typeOfItem = Console.ReadLine();
            int leftSum = 0;
            int rightSum = 0;

            for (int i = 0; i < priceRating.Count; i++)
            {
                if (typeOfItem == "cheap")
                {
                    if (priceRating[i] >= priceRating[entryPoint])
                    {
                        continue;
                    }
                    else
                    {
                        if (i == entryPoint)
                        {
                            break;
                        }
                        else if(i > entryPoint)
                        {
                            rightSum += priceRating[i];
                        }
                        else
                        {
                            leftSum += priceRating[i];
                        }
                    }
                }

                else
                {
                    if (priceRating[i] < priceRating[entryPoint])
                    {
                        continue;
                    }
                    else
                    {
                        if (i == entryPoint)
                        {
                            break;
                        }
                        else if (i > entryPoint)
                        {
                            rightSum += priceRating[i];
                        }
                        else
                        {
                            leftSum += priceRating[i];
                        }
                    }
                }
            }

            string position = null;
            if (leftSum >= rightSum)
            {
                position = "Left";
                Console.WriteLine($"{position} - {leftSum}");
            }
            else
            {
                position = "Right";
                Console.WriteLine($"{position} - {rightSum}");
            }
        }
    }
}
