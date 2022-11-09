using System;

namespace Exercise6
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            double salary = double.Parse(Console.ReadLine());
            bool isBancrupt = false;
            for (int i = 0; i < count; i++)
            {
                string tab = Console.ReadLine();
                switch (tab)
                {
                    case "Facebook":
                        salary -= 150;
                        break;
                    case "Instagram":
                        salary -= 100;
                        break;
                    case "Reddit":
                        salary -= 50;
                        break;
                    default:
                        break;
                }
                if (salary <= 0)
                {
                Console.WriteLine("You have lost your salary.");
                    isBancrupt = true;
                break;

                }
            }

            if (!isBancrupt)
            {
                Console.WriteLine(salary);
            }

           
        }
    }
}
