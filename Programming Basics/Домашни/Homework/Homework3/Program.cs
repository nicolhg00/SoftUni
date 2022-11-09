using System;

namespace Homework3
{
    class Program
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());
            int width = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());
            double percent = double.Parse(Console.ReadLine());
            double volume = length * width * height;
            double liters = volume * 0.001;
            double thePercent = percent * 0.01;
            double theLiters = liters * (1 - thePercent);
            Console.WriteLine(theLiters);
        }
    }
}
