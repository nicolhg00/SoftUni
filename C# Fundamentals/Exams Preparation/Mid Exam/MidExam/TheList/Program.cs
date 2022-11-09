using System;
using System.Linq;

namespace TheList
{
    class Program
    {
        static void Main(string[] args)
        {
            int peopleWaitingForLift = int.Parse(Console.ReadLine());

            int[] wagon = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int peopleOnTheCurrentWagon = 0;
            int peopleOnTheLift = 0;
            bool noMorePeople = false;

            for (int i = 0; i < wagon.Length; i++)
            {
                while (wagon[i] < 4)
                {
                    wagon[i]++;
                    peopleOnTheCurrentWagon++;
                    if (peopleOnTheLift + peopleOnTheCurrentWagon == peopleWaitingForLift)
                    {
                        noMorePeople = true;
                        break;
                    }
                }
                peopleOnTheLift += peopleOnTheCurrentWagon;

                if (noMorePeople)
                {
                    break;
                }
                peopleOnTheCurrentWagon = 0;
            }

            if (peopleWaitingForLift > peopleOnTheLift)
            {
                Console.WriteLine($"There isn't enough space! {peopleWaitingForLift - peopleOnTheLift} people in a queue!");
                Console.WriteLine(string.Join(" ", wagon));
            }
            else if (peopleWaitingForLift < wagon.Length * 4 && wagon.Any(w => w < 4))
            {
                Console.WriteLine("The lift has empty spots!");
                Console.WriteLine(string.Join(" ", wagon));
            }
            else if (wagon.All(w => w == 4) && noMorePeople == true)
            {
                Console.WriteLine(string.Join(" ", wagon));
            }
        }
    }
}
