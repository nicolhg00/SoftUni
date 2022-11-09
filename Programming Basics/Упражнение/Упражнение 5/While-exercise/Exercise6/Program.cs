using System;

namespace Exercise6
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int totalPieces = a * b;
            bool hasCake = true;
            while (hasCake)
            {
                string input = Console.ReadLine();
                if (input == "STOP")
                {

                    break;
                }
                int pieces = int.Parse(input);
                totalPieces -= pieces;
                if (totalPieces < 0)
                {
                    hasCake = false;

                }
            }
            if (hasCake)
            {
                Console.WriteLine($"{totalPieces} pieces are left.");

            }
            else
            {
                Console.WriteLine($"No more cake left! You need {Math.Abs(totalPieces)} pieces more.");
            }
        }
    }
}
