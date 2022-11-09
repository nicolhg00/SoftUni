using System;

namespace _10._Top_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                if (IsTopNumber(i))
                {
                    Console.WriteLine(i);
                }
            }

        }

        private static bool IsTopNumber(int number)
        {
            return IsDivisivleBy(number, 8) && ContainssOddDiggit(number);
        }

        private static bool ContainssOddDiggit(int number)
        {
            while (number != 0)
            {
                int lastDigit = number % 10;
                if (lastDigit %2 != 0)
                {
                    return true;
                }

                number /= 10;
            }
            return false;
        }

        private static bool IsDivisivleBy(int number, int divider)
        {
            int sum = 0;
            while (number != 0)
            {
                int lastDigit = number % 10;
                sum += lastDigit;

                number /= 10;
            }
            return sum % divider == 0;
        }
    }
}
