using System;

namespace Homework6
{
    class Program
    {
        static void Main(string[] args)
        {
            double number = double.Parse(Console.ReadLine());
            string unit = Console.ReadLine();
            string unitSecond = Console.ReadLine();

            if (unit == "m" && unitSecond == "mm")
            {
                
                Console.WriteLine($"{number * 1000:f3}");
            }
            else if (unit == "m" && unitSecond == "cm")
            {
              
                Console.WriteLine($"{number * 100:f3}");
            }
            else if (unit == "cm" && unitSecond == "m")
            {
                Console.WriteLine($"{number * 0.01:f3}");
            }
            else if (unit == "cm" && unitSecond == "mm")
            {
                Console.WriteLine($"{number * 10:f3}");
            }
            else if (unit == "mm" && unitSecond == "m")
            {
                Console.WriteLine($"{number * 0.001:f3}");
            }
            else if (unit == "mm" && unitSecond == "cm")
            {

                Console.WriteLine($"{number * 0.1 :f3}");
            }
        }
    }
}
