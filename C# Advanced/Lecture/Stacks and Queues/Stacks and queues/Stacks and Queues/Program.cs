using System;
using System.Collections.Generic;

namespace Stacks_and_Queues
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<char> stringStack = new Stack<char>();
            string input = Console.ReadLine();

            for (int i = 0; i < input.Length; i++)
            {
                stringStack.Push(input[i]);
            }

            while (stringStack.Count > 0)
            {
                Console.Write(stringStack.Pop());
            }

            Console.WriteLine();
        }
    }
}
