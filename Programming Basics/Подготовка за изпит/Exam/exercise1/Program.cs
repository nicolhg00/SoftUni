using System;

namespace exercise1
{
    class Program
    {
        static void Main(string[] args)
        {
            int anualFee = int.Parse(Console.ReadLine());
            double trainers = anualFee * 0.6;
            double clothes = trainers * 0.8;
            double ball = clothes / 4;
            double accesories = ball / 5;

            Console.WriteLine($"{(trainers+clothes+ball+accesories+anualFee):f2}");
        }
    }
}
