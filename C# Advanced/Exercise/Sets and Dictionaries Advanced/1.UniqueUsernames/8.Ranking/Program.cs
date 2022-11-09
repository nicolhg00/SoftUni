using System;
using System.Collections.Generic;
using System.Linq;

namespace _8.Ranking
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> lines = new Dictionary<string, string>();
            string input = Console.ReadLine();

            while (input != "end of contests")
            {
                string[] tokens = input.Split(":");
                string contests = tokens[0];
                string passwordForContests = tokens[1];

                lines.Add(contests, passwordForContests);

                input = Console.ReadLine();
            }

            SortedDictionary<string, Dictionary<string, int>> database = new SortedDictionary<string, Dictionary<string, int>>();
            string secondInput = Console.ReadLine();

            while (secondInput != "end of submissions")
            {
                string[] secondTokend = secondInput.Split("=>");

                string contest = secondTokend[0];
                string password = secondTokend[1];
                string username = secondTokend[2];
                int points = int.Parse(secondTokend[3]);



                if (lines.ContainsKey(contest) && lines.ContainsValue(password))
                {
                    if (!database.ContainsKey(username))
                    {
                        database.Add(username, new Dictionary<string, int>());
                        database[username].Add(contest, points);
                    }

                    if (database[username].ContainsKey(contest))
                    {

                        if (database[username][contest] < points)
                        {
                            database[username][contest] = points;
                        }
                    }

                    else
                    {
                        database[username].Add(contest, points);
                    }

                }

                secondInput = Console.ReadLine();
            }
            Dictionary<string, int> usernameTotalPoints = new Dictionary<string, int>();

            foreach (var kvp in database)
            {
                usernameTotalPoints[kvp.Key] = kvp.Value.Values.Sum();
            }
            string bestName = usernameTotalPoints.Keys.Max();
            int bestPoints = usernameTotalPoints.Values.Max();


            foreach (var kvp in usernameTotalPoints)
            {
                if (kvp.Value == bestPoints)
                {
                    Console.WriteLine($"Best candidate is {bestName} with total {bestPoints} points.");
                }
            }

            Console.WriteLine("Ranking:");
            foreach (var name in database)
            {
                Dictionary<string, int> dict = name.Value;
                dict = dict.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
                Console.WriteLine("{0}", name.Key);
                foreach (var kvp in dict)
                {
                    Console.WriteLine("#  {0} -> {1}", kvp.Key, kvp.Value);
                }
            }
        }
    }
}
