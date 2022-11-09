using System;
using System.Collections.Generic;

namespace _5.__Multiply_Big_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            string number = Console.ReadLine();
            int multiplier = int.Parse(Console.ReadLine());
            
            int remainder = 0;

            List<string> result = new List<string>();

            for (int i = number.Length-1; i >= 0; i--)
            {
                if (multiplier == 0)
                {
                    Console.WriteLine(0);
                    break;

                }
                int digit = number[i] - '0';

                remainder += multiplier * digit;
                if (remainder > 9)
                {
                    int remainderLastDigit = remainder % 10;
                    remainder /= 10;

                    result.Add(remainderLastDigit.ToString());
                }
                else
                {
                    result.Add(remainder.ToString());
                    remainder = 0;
                }
            }
            if (remainder >0)
            {
                result.Add(remainder.ToString());
            }

            result.Reverse();
            Console.WriteLine(string.Concat(result));
        }
    }
}
