﻿using System;
using System.Runtime.InteropServices;

namespace Exersice9
{
    class Program
    {
        static void Main(string[] args)
        {
            int yield = int.Parse(Console.ReadLine());

            if (yield < 100)
            {
                Console.WriteLine(0);
                Console.WriteLine(0);

                return;
            }
            long totalSpice = 0;
            int days = 0;

            while (yield >= 100)
            {
                days += 1;
                totalSpice += yield - 26;
                yield -= 10;
            }

            totalSpice -= 26;
            Console.WriteLine(days);
            Console.WriteLine(totalSpice);
        }
    }
}
