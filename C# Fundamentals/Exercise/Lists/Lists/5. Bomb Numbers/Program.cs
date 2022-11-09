using System;
using System.Collections.Generic;
using System.Linq;

namespace _5._Bomb_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            int[] boomData = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int boomNumber = boomData[0];
            int boomPower = boomData[1];

            while (true)
            {
                int idx = numbers.IndexOf(boomNumber);

                if (idx == -1)
                {
                    break;
                }

                int startIndex = idx - boomPower;

                if (startIndex < 0)
                {
                    startIndex = 0;
                }
                int count = 2 * boomPower + 1;

                if (count >= numbers.Count - startIndex)
                {
                    count = numbers.Count - startIndex;
                }

                numbers.RemoveRange(startIndex, count);
            }
            int sum = 0;
            foreach (var number in numbers)
            {
                sum += number;
            }
            Console.WriteLine(sum);
        }
    }
}
