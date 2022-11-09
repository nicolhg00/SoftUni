using System;

namespace Exersice6
{
    class Program
    {
        static void Main(string[] args)
        {
            // && - И
            // || - ИЛИ 
            // ! - ОТИЦАНИЕ

            int num = int.Parse(Console.ReadLine());
            if (num >= 100 && num <= 100 && num !=0)
            {
                Console.WriteLine("Yes");
            }
            else
            {
                Console.WriteLine("No");
            }
        }
    }
}
