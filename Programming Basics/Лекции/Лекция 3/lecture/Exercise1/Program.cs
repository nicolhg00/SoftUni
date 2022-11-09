using System;

namespace Exercise1
{
    class Program
    {
        static void Main(string[] args)
        {
            // cloudy , sunny , rainy, icy

            string weather = Console.ReadLine();
          
            switch (weather)
            {
                case "cloudy":
                    Console.WriteLine("Take your jaket!");
                    break;

                case "sunny":
                    Console.WriteLine("Take your sunscreen!");
                    break;

                case "rainy":
                case "stormy":
                    Console.WriteLine("Take your umbrella!");
                    break;
                case "icy":
                    Console.WriteLine("Go skiing!");
                    break;
                default:
                    Console.WriteLine("error");
                    break;
            }
        }
    }
}
