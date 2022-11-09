using System;

namespace exercise4
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isReached = false;
            int steps = 0;
            int target = 10000;
            bool isGoingHome = false;
            while (!isReached && !isGoingHome)
            {
                string input = Console.ReadLine();
                if (input == "Going home")
                {
                    isGoingHome = true;
                    input = Console.ReadLine();
                }

                steps += int.Parse(input);
                if (steps >= target)
                {
                    isReached = true;
                }
            }
            if (isReached)
            {
                Console.WriteLine("Goal reached! Good job!");
                Console.WriteLine($"{steps - target} steps over the goal!");
            }
            else
            {
                Console.WriteLine($"{target-steps} more steps to reach goal.");
            }
        }
    }
}
