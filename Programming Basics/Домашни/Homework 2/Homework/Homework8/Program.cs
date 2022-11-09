using System;

namespace Homework8
{
    class Program
    {
        static void Main(string[] args)
        {
            string month = Console.ReadLine();
            int nights = int.Parse(Console.ReadLine());
            double apartment = 0;
            double studio = 0;

            switch (month)
            {
                case "May":
                case "October":
                    studio = 50;
                    apartment = 65;
                    if (nights > 7 && nights <=14)
                    {
                        studio -= 0.5 * studio; 
                    }
                    else if (nights > 14)
                    {
                        studio -= 0.30 * studio;
                        apartment -= 0.10 * apartment;
                    }

                    break;
               
                case "June":
                case "September":
                    studio = 75.20;
                    apartment = 68.70;
                    if (nights > 14)
                    {
                        studio -= 0.20 * studio;
                        apartment -= 0.10 * apartment;
                    }
                    break;

                case "July":
                case "August":
                    studio = 76;
                    apartment = 77;
                    if (nights > 14)
                    {
                        apartment -= 0.10 * apartment;
                    }
                    break;

                default:
                    break;
            }
            Console.WriteLine($"Apartment: {apartment * nights :f2} lv.");
            Console.WriteLine($"Studio: {studio * nights :f2} lv.");
        }
    }
}
