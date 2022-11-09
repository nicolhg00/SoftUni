using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem3
{
    class Program
    {
        static void Main(string[] args)
        {
            var guestList = new Dictionary<string, List<string>>();

            string input = Console.ReadLine();

            int counterUnlike = 0;

            while (input != "Stop")
            {
                string[] inputSplit = input
                    .Split("-", StringSplitOptions.RemoveEmptyEntries);
                string action = inputSplit[0];
                string guest = inputSplit[1];
                string meal = inputSplit[2];

                if (action == "Like")
                {
                    if (!guestList.ContainsKey(guest))
                    {
                        guestList[guest] = new List<string>();
                        guestList[guest].Add(meal);
                    }
                    else if (!guestList[guest].Contains(meal))
                    {
                        guestList[guest].Add(meal);
                    }
                }
                else if (action == "Unlike")
                {
                    if (guestList.ContainsKey(guest))
                    {
                        if (guestList[guest].Contains(meal))
                        {
                            guestList[guest].Remove(meal);
                            Console.WriteLine($"{guest} doesn't like the {meal}.");
                            counterUnlike++;
                        }
                        else
                        {
                            Console.WriteLine($"{guest} doesn't have the {meal} in his/her collection.");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"{guest} is not at the party.");
                    }
                }

                input = Console.ReadLine();
            }


            foreach (var (guest, meals) in guestList.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key))
            {
                Console.WriteLine(guest + ": " + string.Join(", ", meals));
            }

            Console.WriteLine($"Unliked meals: {counterUnlike}");
        }
    }
}
