using System;
using System.Collections.Generic;
using System.Linq;

namespace MovingTarget
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> targets = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            string command = Console.ReadLine();

            while (command != "End")
            {
                string[] targetsM = command.Split(" ");
                int index1 = 0;
                int index2 = 0;

                switch (targetsM[0])
                {
                    case "Shoot":
                        index1 = int.Parse(targetsM[1]);
                        index2 = int.Parse(targetsM[2]);

                        if (index1 < targets.Count && index1 > -1)
                        {
                                targets[index1] -= index2;

                            if (targets[index1] <= 0)  
                            {
                                targets.RemoveAt(index1);
                            }

                        }
                        break;

                    case "Add":
                        index1 = int.Parse(targetsM[1]);
                        index2 = int.Parse(targetsM[2]);

                        if (index1 < targets.Count && index1 > -1)
                        {
                            targets.Insert(index1, index2);
                        }
                        else
                        {
                            Console.WriteLine("Invalid placement!");
                        }
                        break;

                    case "Strike":
                        index1 = int.Parse(targetsM[1]);
                        index2 = int.Parse(targetsM[2]);
                        int startIndex = index1 - index2;
                        int endIndex = index1 + index2;

                        if (startIndex >= 0 && endIndex < targets.Count)
                        {
                            targets.RemoveRange(startIndex, 2 * index2 + 1);
                        }
                        else
                        {
                            Console.WriteLine("Strike missed!");
                        }
                        break;

                    default:
                        break;
                }
                command = Console.ReadLine();
            }

            Console.WriteLine(string.Join("|", targets));
        }
    }
}
