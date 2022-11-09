using System;
using System.Collections.Generic;
using System.Linq;

namespace _9._ForceBook
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = null;
            //<member,side>
            var users = new Dictionary<string, string>();

            while ((command = Console.ReadLine()) != "Lumpawaroo")
            {
                string side = null;
                string member = null;
                var action = command.Split();

                if (action.Contains("|"))
                {
                    side = command.Split(" | ", 2)[0];
                    member = command.Split(" | ", 2)[1];

                    if (!users.ContainsKey(member))
                        users.Add(member, side);
                }
                else if (action.Contains("->"))
                {
                    side = command.Split(" -> ", 2)[1];
                    member = command.Split(" -> ", 2)[0];

                    if (users.ContainsKey(member))
                        users[member] = side;
                    else
                        users.Add(member, side);


                    Console.WriteLine($"{member} joins the {side} side!");
                }
            }

            foreach (var orderedSide in users
                .GroupBy(x => x.Value)
                .OrderByDescending(x => x.Count())
                .ThenBy(x => x.Key))
            {
                Console.WriteLine($"Side: {orderedSide.Key}, Members: {orderedSide.Count()}");
                foreach (var orderedUser in orderedSide.OrderBy(x => x.Key))
                {
                    Console.WriteLine($"! {orderedUser.Key}");
                }
            }
        }
    }
}
