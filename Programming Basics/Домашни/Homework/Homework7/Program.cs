using System;

namespace Homework7
{
    class Program
    {
        static void Main(string[] args)
        {
            double income = double.Parse(Console.ReadLine());
            double success = double.Parse(Console.ReadLine());
            double minimalSalary = double.Parse(Console.ReadLine());
            double scholarship = 0.0;
            double socialScholarship = 0.0;
            if (success >= 5.50)
            {
                scholarship = success * 25;
            }
            else if (income < minimalSalary && success > 4.50)
            {
                socialScholarship = 0.35 * minimalSalary;
               
            }
            else
            {
                Console.WriteLine("You cannot get a scholarship!");
            }
            if (socialScholarship > scholarship)
            {
                Console.WriteLine($"You get a Social scholarship {Math.Floor(socialScholarship)} BGN");
            }
            else if (scholarship > socialScholarship)
            {
                Console.WriteLine($"You get a scholarship for excellent results {Math.Floor(scholarship)} BGN");
            }
        }
    }
}
