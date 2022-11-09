using System;

namespace Exercise2
{
    class Program
    {
        static void Main(string[] args)
        {
            int poorGradesLimit = int.Parse(Console.ReadLine());
            double sumGrades = 0;
            int problemCount = 0;
            string problemName = "";
            int poorGradesCount = 0;
            bool needsBreak = false;

            while (!needsBreak)
            {
                string input = Console.ReadLine();
                if (input == "Enough")
                {
                    break;
                }
                problemName = input;
                problemCount++;

                int grade = int.Parse(Console.ReadLine());
                if (grade <= 4)
                {
                    poorGradesCount++;
                }
                if (poorGradesCount == poorGradesLimit)
                {
                    needsBreak = true;
                }

                sumGrades += grade;
            }
            if (needsBreak)
            {
                Console.WriteLine($"You need a break, {poorGradesCount} poor grades.");
            }
            else
            {
                Console.WriteLine($"Average score: {sumGrades / problemCount:f2}");
                Console.WriteLine($"Number of problems: {problemCount}");
                Console.WriteLine($"Last problem: {problemName}");
            }

        }
    }
}
