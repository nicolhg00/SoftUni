﻿using System;

namespace Exersice5
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNum = int.Parse(Console.ReadLine());
            int secondNum = int.Parse(Console.ReadLine());

            for (int i = firstNum; i <= secondNum; i++)
            {
                Console.Write($"{(char)i} ");
            }
        }
    }
}
