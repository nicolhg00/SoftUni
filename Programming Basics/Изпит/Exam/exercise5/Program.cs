using System;

namespace exercise5
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int numOfAdults = 0;
            int numOfKids = 0;
            int numOfToys = 0;
            int numOfSweaters = 0;
            double moneyForToys = 5;
            double moneyForSweaters = 15;
            
            while (input != "Christmas")
            {
                int age = int.Parse(input);
                if (age <= 16)
                {
                    numOfKids++;
                    numOfToys++;
                }
                else
                {
                    numOfAdults++;
                    numOfSweaters++;
                }
                input = Console.ReadLine();
            }
            double totalPriceOfToys = numOfToys * moneyForToys;
            double totalPriceOfSweaters = numOfSweaters*moneyForSweaters;
            Console.WriteLine($"Number of adults: {numOfAdults}");
            Console.WriteLine($"Number of kids: {numOfKids}");
            Console.WriteLine($"Money for toys: {totalPriceOfToys}");
            Console.WriteLine($"Money for sweaters: {totalPriceOfSweaters}");
        }
    }
}
