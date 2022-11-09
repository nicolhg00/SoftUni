using System;

namespace exercise3
{
    class Program
    {
        static void Main(string[] args)
        {
            string destination = Console.ReadLine();
            string dates = Console.ReadLine();
            int nights = int.Parse(Console.ReadLine());
            int priceForNight = 0;

            switch (destination)
            {
                case "France":
                    switch (dates)
                    {
                        case "21-23":
                            priceForNight = 30;
                            break;
                        case "24-27":
                            priceForNight = 35;
                            break;
                        case "28-31":
                            priceForNight = 40;
                            break;
                            
                        default:
                            break;
                    }
                    break;
                case "Italy":
                    switch (dates)
                    {
                        case "21-23":
                            priceForNight = 28;
                            break;
                        case "24-27":
                            priceForNight = 32;
                            break;
                        case "28-31":
                            priceForNight = 39;
                            break;

                        default:
                            break;
                    }
                    break;
                case "Germany":
                    switch (dates)
                    {
                        case "21-23":
                            priceForNight = 32;
                            break;
                        case "24-27":
                            priceForNight = 37;
                            break;
                        case "28-31":
                            priceForNight = 43;
                            break;

                        default:
                            break;
                    }
                    break;
                default:
                    break;
            }
            Console.WriteLine($"Easter trip to {destination} : {nights*priceForNight:f2} leva.");
        }
    }
}
