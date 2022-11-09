using System;

namespace Homework2
{
    class Program
    {
        static void Main(string[] args)
        {
            double priceBerries = double.Parse(Console.ReadLine());
            double bananas = double.Parse(Console.ReadLine());
            double oranges = double.Parse(Console.ReadLine());
            double raspberries = double.Parse(Console.ReadLine());
            double berries = double.Parse(Console.ReadLine());
            double priceRaspberries = priceBerries / 2;
            double priceOranges = priceRaspberries * 0.60;
            double priceBananas = priceRaspberries * 0.20;
            double sum = priceRaspberries*raspberries + priceOranges*oranges + priceBerries*berries + priceBananas*bananas;
            Console.WriteLine(sum);
        }
    }
}
