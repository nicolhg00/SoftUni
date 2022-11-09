using System;
using System.Collections.Generic;
using System.Linq;

namespace _5.AppliedArithemtics
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToArray();
            Action<int[]> printer = number => Console.WriteLine(string.Join(" ", number));
            string command = Console.ReadLine();

            while (command != "end")
            {
                switch (command)
                {
                    case "add":
                        numbers = ForEach(numbers, n => ++n);
                    break;
                    case "multiply":
                        numbers = ForEach(numbers, n => n*2);
                        break;
                    case "subtract":
                        numbers = ForEach(numbers, n => --n);
                        break;
                    case "print":
                        printer(numbers);
                        break;

                    default:
                        break;
                }
                command = Console.ReadLine();
            }

            
        }

        private static int[] ForEach(int[] numbers, Func<int, int> func)
        => numbers.Select(number => func(number)).ToArray();
        
    }
}
