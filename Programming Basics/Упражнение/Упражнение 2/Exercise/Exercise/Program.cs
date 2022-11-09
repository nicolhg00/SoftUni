using System;

namespace Exercise
{
    class Program
    {
        static void Main(string[] args)
        {
            int fisrtSeconds = int.Parse(Console.ReadLine());
            int secondSeconds = int.Parse(Console.ReadLine());
            int thirdSeconds = int.Parse(Console.ReadLine());

            int totalSeconds = fisrtSeconds + secondSeconds + thirdSeconds;

            int minutes = totalSeconds / 60;
            int seconds = totalSeconds % 60;

            
            if (seconds < 10)
            {
                Console.WriteLine($"{ minutes}:0{seconds}");
            }
            else
            {
                Console.WriteLine($"{ minutes}:{seconds}");
            }

        }
    }
}
