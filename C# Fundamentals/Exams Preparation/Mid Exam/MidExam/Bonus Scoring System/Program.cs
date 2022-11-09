using System;
using System.Linq;

namespace Bonus_Scoring_System
{
    class Program
    {
        static void Main(string[] args)
        {
            int studentCount = int.Parse(Console.ReadLine());
            int lecturesCount = int.Parse(Console.ReadLine());
            int initialBonus = int.Parse(Console.ReadLine());
            int maxBonus = int.MinValue;
            int maxAttended = int.MinValue;

            if (studentCount == 0 || lecturesCount == 0)
            {
                Console.WriteLine($"Max Bonus: 0.");
                Console.WriteLine($"The student has attended 0 lectures.");
                return;
            }

            for (int i = 0; i < studentCount; i++)
            {
               int attandencesBonus = int.Parse(Console.ReadLine());
               double totalBonus = Math.Ceiling(attandencesBonus*1.0 / lecturesCount * (5 + initialBonus));

                if (totalBonus > maxBonus)
                {
                    maxBonus = (int)totalBonus;
                    maxAttended = attandencesBonus;
                }
            }

            Console.WriteLine($"Max Bonus: {maxBonus}.");
            Console.WriteLine($"The student has attended {maxAttended} lectures.");
        }
    }
}
