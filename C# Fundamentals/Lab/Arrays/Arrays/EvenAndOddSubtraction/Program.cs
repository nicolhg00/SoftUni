using System;
using System.Linq;

namespace EvenAndOddSubtraction
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] number = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int sumOdd = 0;
            int sumEven = 0;
            for (int i = 0; i < number.Length; i++)
            {
                int currentNumber = number[i];
                if (currentNumber % 2 ==0)
                {
                    sumEven += currentNumber;
                }
                else
                {
                    sumOdd += currentNumber;
                }
            }
            Console.WriteLine(sumEven-sumOdd);
        }
    }
}
