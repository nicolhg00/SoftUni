using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingList
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> shoppingList = Console.ReadLine()
                .Split("!")
                .ToList();

            string command = Console.ReadLine();

            while (command != "Go Shopping!")
            {
                string[] tokens = command.Split(" ");

                switch (tokens[0])
                {
                    case "Urgent":
                        string itemsToUrgent = tokens[1];

                        if (!shoppingList.Contains(itemsToUrgent))
                        {
                            shoppingList.Insert(0, itemsToUrgent);
                        }
                        break;

                    case "Unnecessary":
                        string itemsToRemove = tokens[1];

                        if (shoppingList.Contains(itemsToRemove))
                        {
                            shoppingList.Remove(itemsToRemove);
                        }
                        break;

                    case "Correct":
                        
                        string oldItem = tokens[1];
                        string newItem = tokens[2];

                        if (shoppingList.Contains(oldItem))
                        {
                            shoppingList.Insert(shoppingList.IndexOf(oldItem) + 1, newItem);
                            shoppingList.Remove(oldItem);
                        }
                        break;

                    case "Rearrange":
                        string itemToRearrange = tokens[1];

                        if (shoppingList.Contains(itemToRearrange))
                        {
                            shoppingList.Remove(itemToRearrange);
                            shoppingList.Add(itemToRearrange);
                        }
                        break;
                    default:
                        break;
                }
                command = Console.ReadLine();
            }

            Console.WriteLine(string.Join(", ",shoppingList));
        }
    }
}
