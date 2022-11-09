using System;

namespace Homework
{
    class Program
    {
        static void Main(string[] args)
        {
            int daysOfTheCompany = int.Parse(Console.ReadLine());
            int numberOfTheSweets = int.Parse(Console.ReadLine());
            int numberOfTheCake = int.Parse(Console.ReadLine());
            int numberOfTheWaffles = int.Parse(Console.ReadLine());
            int numberOfThePanecakes = int.Parse(Console.ReadLine());
            double sumForADay = numberOfTheSweets*(numberOfTheCake * 45 + numberOfThePanecakes * 3.20 + numberOfTheWaffles * 5.80);
            double sum = sumForADay * daysOfTheCompany;
            double cost = 0.125 * sum;
            Console.WriteLine(sum-cost);
        }
    }
}
