using System;

namespace exersice4
{
    class Program
    {
        static void Main(string[] args)
        {
            int width = int.Parse(Console.ReadLine()); 
            int length = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());

            int freeSpaceVolume = width * length * height;
            int spaceTaken = 0;
            string input = Console.ReadLine();

            while (input != "Done")
            {
                spaceTaken += int.Parse(input);
                if (spaceTaken >= freeSpaceVolume)
                {
                    Console.WriteLine($"No more free space! You need {spaceTaken-freeSpaceVolume} Cubic meters more.");
                    break;
                }
                input = Console.ReadLine();
            }

            if (input == "Done")
            {
              Console.WriteLine($"{freeSpaceVolume-spaceTaken} Cubic meters left.");
            }
          
        }
    }
}
