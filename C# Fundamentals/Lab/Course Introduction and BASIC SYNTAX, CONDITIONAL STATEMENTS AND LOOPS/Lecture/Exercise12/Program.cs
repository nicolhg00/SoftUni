using System;

namespace Exercise12
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            while (number %2 != 0)
            {
                Console.WriteLine("Please write an even number.");
                number = int.Parse(Console.ReadLine());
            }
            if (number > 0)
            {
               Console.WriteLine($"The number is: {number}");
            }
            else
            {
                Console.WriteLine($"The number is: {number*(-1)}");
            }
            
        }
    }
}
