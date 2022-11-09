using System;

namespace FloatingEquality
{
    class Program
    {
        static void Main(string[] args)
        {
            
                decimal number1 = decimal.Parse(Console.ReadLine());
                decimal number2 = decimal.Parse(Console.ReadLine());
                decimal eps = 0.000001m;

                if (Math.Abs(number1 - number2) == eps)
                {
                    Console.WriteLine("False");
                }
                else if (Math.Abs(number1 - number2) > eps)
                {
                    Console.WriteLine("False");
                }
                else
                {
                    Console.WriteLine("True");
                }
            
        }
    }
}
