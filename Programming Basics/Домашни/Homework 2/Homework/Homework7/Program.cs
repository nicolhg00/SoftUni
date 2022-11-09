using System;

namespace Homework7
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            string place = "";
            string where = "";
            switch (season)
            {
                case "summer":
                    where = "Camp";
                    if (budget <= 100)
                    {
                        place = "Bulgaria";
                        budget = 0.30 * budget;
                    }
                    else if (budget <= 1000)
                    {
                        place = "Balkans";
                        budget = 0.40 * budget;
                    }
                    else if (budget >1000)
                    {
                        where = "Hotel";
                        place = "Europe";
                        budget = 0.90 * budget;
                    }
                    break;
                case "winter":
                    where = "Hotel";
                    if (budget <= 100)
                    {
                        place = "Bulgaria";
                        budget = 0.70 * budget;
                    }
                    else if (budget <= 1000)
                    {
                        place = "Balkans";
                        budget = 0.80 * budget;
                    }
                    else if (budget > 1000)
                    {
                        
                        place = "Europe";
                        budget = 0.90 * budget;
                    }
                    break;

                default:
                    break;
            }
            Console.WriteLine($"Somewhere in {place}");
            Console.WriteLine($"{where} - {budget :f2}");
        }
    }
}
