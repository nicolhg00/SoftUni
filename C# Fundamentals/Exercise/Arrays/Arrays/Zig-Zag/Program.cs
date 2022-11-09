using System;
using System.Linq;

namespace Zig_Zag
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            int[] first = new int[size];
            int[] second = new int[size];
            for (int i = 0; i < size; i++)
            {
                int[] number = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();
                int firstNumber = number[0];
                int secondNumber = number[1];

                if (i % 2 != 0)
                {
                    first[i] = secondNumber;
                    second[i] = firstNumber;
                }
                else
                {
                    first[i] = firstNumber;
                    second[i] = secondNumber;
                }
            }
            Console.WriteLine(string.Join(" ",first ));
            Console.WriteLine(string.Join(" ",second ));
        }
    }
}
