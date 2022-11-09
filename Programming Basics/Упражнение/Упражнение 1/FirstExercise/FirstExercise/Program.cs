using System;

namespace FirstExercise
{
    class Program
    {
        static void Main(string[] args)
        {
            double rent = double.Parse(Console.ReadLine());
            double cake = rent * 0.20 ;
            double drinks = cake * 0.55  ;
            double animator = rent / 3;

            double sum = rent + cake + drinks + animator;
            Console.WriteLine(sum);

        }
    }
}
