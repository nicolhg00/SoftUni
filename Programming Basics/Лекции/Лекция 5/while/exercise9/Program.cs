using System;

namespace exercise9
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int counter = 1;
            int failsCounter = 0;
            double gradeSum = 0;

            while (counter <= 12)
            {
                double grade = double.Parse(Console.ReadLine());
                if (grade >= 4)
                {
                    gradeSum += grade;
                    counter++;
                }
                else
                {
                    failsCounter++;
                }
                if (failsCounter == 2)
                {
                    break;
                }
            }

            if (failsCounter == 2)
            {
                Console.WriteLine($"{name} has been excluded at {(counter)} grade");
            }
            else
            {
                double averageGrade = gradeSum / 12;
                Console.WriteLine($"{name} graduated. Average grade: {averageGrade:f2}");
            }

        }
    }
}
