using System;

namespace Homework6
{
    class Program
    {
        static void Main(string[] args)
        {
            //1,2,5,7,9
            double weather = double.Parse(Console.ReadLine());
            string time = Console.ReadLine();
            string outfit = "";
            string shoes = "";
            switch (time)
            {
                case "Morning":
                    if (10 <= weather && weather <= 18)
                    {
                        outfit = "Sweatshirt";
                        shoes = "Sneakers";
                    }
                    else if (18 < weather && weather <= 24)
                    {
                        outfit = "Shirt";
                        shoes = "Moccasins";
                    }
                   
                    else if (weather >= 25)
                    {
                        outfit = "T-Shirt";
                        shoes = "Sandals";
                    } 
                    break;
                case "Afternoon":
                    if (10 <= weather && weather <= 18)
                    {
                        outfit = "Shirt";
                        shoes = "Moccasins";
                    }
                    else if (18 < weather && weather <= 24)
                    {
                        outfit = "T-Shirt";
                        shoes = "Sandals";
                    }

                    else if (weather >= 25)
                    {
                        outfit = "Swim Suit";
                        shoes = "Barefoot";
                    }
                    break;

                case "Evening":
                    if (10 <= weather && weather <= 18)
                    {
                        outfit = "Shirt";
                        shoes = "Moccasins";
                    }
                    else if (18 < weather && weather <= 24)
                    {
                        outfit = "Shirt";
                        shoes = "Moccasins";
                    }

                    else if (weather >= 25)
                    {
                        outfit = "Shirt";
                        shoes = "Moccasins";
                    }
                    break;
                default:
                    break;
            }
            Console.WriteLine($"It's {weather} degrees, get your {outfit} and {shoes}.");
        }
    }
}
