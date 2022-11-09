using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> sugarCubes = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            string command = Console.ReadLine();

            while (command != "Mort")
            {
                string[] targets = command.Split();
                int index1 = 0;
                int index2 = 0;
                switch (targets[0])
                {
                    case "Add":
                        index1 = int.Parse(targets[1]);
                        sugarCubes.Add(index1);
                        break;

                    case "Remove":
                        index1 = int.Parse(targets[1]);
                        sugarCubes.Remove(index1);
                        break;

                    case "Replace":
                        index1 = int.Parse(targets[1]);
                        index2 = int.Parse(targets[2]);
                       
                        if (sugarCubes.Contains(index1))
                        {
                            sugarCubes.Insert(sugarCubes.IndexOf(index1) + 1, index2);
                            sugarCubes.Remove(index1);
                        }
                        break;

                    case "Collapse":
                        index1 = int.Parse(targets[1]);
                        for (int i = 0; i < sugarCubes.Count; i++)
                        {
                            if (index1 > sugarCubes[i])
                            {
                                sugarCubes.Remove(sugarCubes[i]);
                                i--;
                            }
                        }
                        break;

                    default:
                        break;
                }
                command = Console.ReadLine();
            }
            Console.WriteLine(string.Join(" ",sugarCubes));
        }
    }
}
