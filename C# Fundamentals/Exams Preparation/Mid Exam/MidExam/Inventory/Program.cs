using System;
using System.Collections.Generic;
using System.Linq;

namespace Inventory
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> items = Console.ReadLine()
                .Split(", ")
                .ToList();

            string input = Console.ReadLine();

            while (input != "Craft!")
            {
                string[] command = input
                    .Split(" - ");

                switch (command[0])
                {
                    case "Collect":
                        string itemToAdd = command[1];
                        if (!items.Contains(itemToAdd))
                        {
                            items.Add(itemToAdd);
                        }
                        break;

                    case "Drop":
                        string itemToDrop = command[1];
                        if (items.Contains(itemToDrop))
                        {
                            items.Remove(itemToDrop);
                        }
                        break;

                    case "Combine Items":
                        string[] itemToCombine = command[1].Split(':');
                        string oldItem = itemToCombine[0];
                        string newItem = itemToCombine[1];

                        if (items.Contains(oldItem))
                        {
                            items.Insert(items.IndexOf(oldItem) + 1, newItem);
                        }

                        break;

                    case "Renew":
                        string itemToRenew = command[1];

                        if (items.Contains(itemToRenew))
                        {
                            items.Remove(itemToRenew);
                            items.Add(itemToRenew);
                        }
                        break;
                    default:
                        break;
                }
                input = Console.ReadLine();
            }
            Console.WriteLine(string.Join(", ",items));
        }
    }
}
