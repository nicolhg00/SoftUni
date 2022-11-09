﻿using System;

namespace Exersice10
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());
            int y = int.Parse(Console.ReadLine());

            int originN = n;
            int targets = 0;
            while (n >= m)
            {
                n -= m;
                targets += 1;

                if (n == originN / 2 && y > 0)
                {
                    n /= y;
                }
            }
            Console.WriteLine(n);
            Console.WriteLine(targets);
        }
    }
}
