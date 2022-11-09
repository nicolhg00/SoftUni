using System;

namespace exercise6
{
    class Program
    {
        static void Main(string[] args)
        {
            int numOfCompany = int.Parse(Console.ReadLine());
            
            double max = double.MinValue;
            string maxN = "";

            for (int i = 0; i < numOfCompany; i++)
            {
                string nameOfCompany = Console.ReadLine();
                string numOfPeople = Console.ReadLine();
                int totalSumOfPassenger = 0;
                int flights = 0;
                while (numOfPeople != "Finish")
                {
                    totalSumOfPassenger += int.Parse(numOfPeople);
                    flights++;
                    numOfPeople = Console.ReadLine();


                }
                double average = (totalSumOfPassenger / flights);
                if (average > max)
                {
                    max = average;
                    maxN = nameOfCompany;

                }
                Console.WriteLine($"{nameOfCompany}: {Math.Floor(average)} passengers.");
            }
            Console.WriteLine($"{maxN} has most passengers per flight: {max}");

        }
    }
}