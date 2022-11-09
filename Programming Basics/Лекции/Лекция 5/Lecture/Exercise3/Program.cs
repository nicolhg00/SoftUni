using System;

namespace Exercise3
{
    class Program
    {
        static void Main(string[] args)
        {
            string year = Console.ReadLine();
           double holidays =double.Parse(Console.ReadLine());
           double weekendAtCountry = double.Parse(Console.ReadLine());
            double volleyAtHolidays = holidays * (0.6666667);
            double volleyAtCountry = weekendAtCountry;
            double volleyAtWeekends = (48 - weekendAtCountry) * 0.75;
            double totalGaames = volleyAtCountry + volleyAtHolidays + volleyAtWeekends;
            if (year == "leap")
            {
                totalGaames += totalGaames * 0.15;
                Console.WriteLine(Math.Floor(totalGaames));
            }
            else if (year == "normal")
            {
                Console.WriteLine(Math.Floor(totalGaames));
            }
                            

        }
    }
}
