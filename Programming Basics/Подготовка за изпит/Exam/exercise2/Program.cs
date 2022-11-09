using System;

namespace exercise2
{
    class Program
    {
        static void Main(string[] args)
        {
            int pictureTime = int.Parse(Console.ReadLine());
            int numberOfScenes = int.Parse(Console.ReadLine());
            int sceneDuration = int.Parse(Console.ReadLine());

            double locationPrep = pictureTime * 0.15;
            double totalTimeForShooting = numberOfScenes * sceneDuration;
            double totalTime = locationPrep + totalTimeForShooting;

            double timeDifference = Math.Abs(pictureTime - totalTime);

            double roundedDifference = Math.Round(timeDifference);
            if (pictureTime >= totalTime)
            {
                Console.WriteLine($"You managed to finish the movie on time! You have {roundedDifference} minutes left!");
            }
            else
            {
                Console.WriteLine($"Time is up! To complete the movie you need {roundedDifference} minutes.");
            }
        }
    }
}
