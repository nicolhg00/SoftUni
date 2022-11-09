using System;

namespace exercise1
{
    class Program
    {
        static void Main(string[] args)
        {
            int priceVideoCard = int.Parse(Console.ReadLine());
            int priceAdapter = int.Parse(Console.ReadLine());
            double priceCurrent = double.Parse(Console.ReadLine());
            double profit = double.Parse(Console.ReadLine());

            
            int totalMoney = (priceVideoCard*13) + (priceAdapter*13) + 1000;
            double totalPofit = 13 * (profit - priceCurrent);
            double daysForReturn = Math.Ceiling(totalMoney / totalPofit);

            Console.WriteLine(totalMoney);
            Console.WriteLine(daysForReturn);

        }
    }
}
