using System;

namespace Exercise8
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int studentCount = int.Parse(Console.ReadLine());
            double lightsabersPrice = double.Parse(Console.ReadLine());
            double robesPrice = double.Parse(Console.ReadLine());
            double beltPrice = double.Parse(Console.ReadLine());

            int lightsabersCount = (int)Math.Ceiling(studentCount * 1.1);
            int beltsCount = studentCount - studentCount / 6;

            double totalPrice = lightsabersPrice * lightsabersCount +
                robesPrice * studentCount + beltPrice * beltsCount;
            if (budget >= totalPrice)
            {
                Console.WriteLine($"The money is enough - it would cost {totalPrice:f2}lv.");
            }
            else
            {
                Console.WriteLine($"Ivan Cho will need {(totalPrice - budget):f2}lv more.");
            }
        }
    }
}
