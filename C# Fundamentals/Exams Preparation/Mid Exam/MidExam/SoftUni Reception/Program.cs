using System;

namespace SoftUni_Reception
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstEmployeeEfficiency = int.Parse(Console.ReadLine());
            int secondEmployeeEfficiency = int.Parse(Console.ReadLine());
            int thirdEmployeeEfficiency = int.Parse(Console.ReadLine());
            int studets = int.Parse(Console.ReadLine());
            int studetsPerHour = firstEmployeeEfficiency + secondEmployeeEfficiency + thirdEmployeeEfficiency;

            int hours = 0;

            while (studets > 0)
            {
                hours++;
                if (hours % 4 == 0)
                {
                    continue;
                }
                else
                {
                    studets -= studetsPerHour;
                }
            }
            Console.WriteLine($"Time needed: {hours}h.");
        }
    }
}
