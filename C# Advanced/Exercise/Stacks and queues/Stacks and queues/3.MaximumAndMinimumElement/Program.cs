using System;
using System.Collections.Generic;
using System.Linq;

namespace _3.MaximumAndMinimumElement
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> stack = new Stack<int>();
            int n = int.Parse(Console.ReadLine());

            while (n != 0)
            {
                int[] command = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();
                switch (command[0])
                {
                    case 1:
                        stack.Push(command[1]);
                        break;
                    case 2:
                        if (stack.Count > 0)
                        {
                            stack.Pop();
                        }
                        else
                        {
                            n--;
                            continue;
                        }

                        break;
                    case 3:
                        if (stack.Count == 0)
                        {
                            n--;
                            continue;
                        }
                        Console.WriteLine(stack.Max());
                        break;
                    case 4:
                        if (stack.Count == 0)
                        {
                            n--;
                            continue;
                        }
                        Console.WriteLine(stack.Min());
                        break;
                    default:
                        break;
                }
                n--;
            }

            Console.WriteLine(string.Join(", ", stack));
        }
    }
}
