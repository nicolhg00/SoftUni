﻿using System;
using System.Linq;

namespace EqualArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr1 = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] arr2 = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int sum = 0;
            int sum2 = 0;
            for (int i = 0; i < arr1.Length; i++)
            {
                sum += arr1[i];
                sum2 += arr2[i];
                if (arr1[i] != arr2[i])
                {
                    Console.WriteLine($"Arrays are not identical. Found difference at {i} index");
                    break;
                }

            }
            if (sum == sum2)
            {
                Console.WriteLine($"Arrays are identical. Sum: {sum}");
            }


        }
    }
}
