using System;

namespace Homework5
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            string typeOfRoom = Console.ReadLine();
            string rating = Console.ReadLine();
            double priceForNight = 0;
            double discount = 0;
            switch (typeOfRoom)
            {
                case "room for one person":
                    priceForNight = 18;
                    break;
                case "apartment":
                    priceForNight = 25;
                    if (days < 10)
                    {
                        discount = 0.30;
                    }
                    else if ( days >= 10 && days <= 15)
                    {
                        discount = 0.35;
                    }
                    else 
                    {
                        discount = 0.50;
                    }
                    break;
                case "president apartment":
                    priceForNight = 35;
                    if (days < 10)
                    {
                        discount = 0.10;
                    }
                    else if (days >= 10 && days <= 15)
                    {
                        discount = 0.15;
                    }
                    else
                    {
                        discount = 0.20;
                    }
                    break;
                default:
                    break;
            }
            double totalPrice = (days - 1) * priceForNight;
            totalPrice -= totalPrice * discount;
            if (rating == "positive")
            {
                totalPrice += totalPrice * 0.25;
            }
            else
            {
                totalPrice -= totalPrice * 0.10;
            }
            Console.WriteLine($"{totalPrice :f2}");
        }
    }
}
