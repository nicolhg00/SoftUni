using System;
using System.Collections.Generic;
using System.Linq;

namespace TheFightForGondor
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<int> plates = new List<int>(Console.ReadLine().Split(" ").Select(int.Parse).ToArray());
            Stack<int> waves = new Stack<int>();

            bool platesDefenseDestroed = false;


            for (int i = 1; i <= n; i++)
            {
                waves = new Stack<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());
                if (i % 3 == 0)
                {
                    int addNewPlate = int.Parse(Console.ReadLine());

                    plates.Add(addNewPlate);
                }
                while (waves.Count != 0 && plates.Count != 0)
                {
                    
                    if (waves.Peek() > plates.First())
                    {
                        waves.Push(waves.Pop() - plates.First());
                        plates.RemoveAt(0);

                    }
                    else if (plates.First() > waves.Peek())
                    {
                        
                       plates[0] -= waves.Pop();
                    }
                    else if (plates.First() == waves.Peek())
                    {
                        waves.Pop();
                        plates.RemoveAt(0);
                    }
                    
                    if (plates.Count == 0)
                    {
                        platesDefenseDestroed = true;
                        break;
                    }
                }
                if (platesDefenseDestroed)
                {
                    break;
                }
            }
            if (platesDefenseDestroed)
            {
                Console.WriteLine("The orcs successfully destroyed the Gondor's defense.");
            }
            else
            {
                Console.WriteLine("The people successfully repulsed the orc's attack.");
            }

            if (waves.Count > 0)
            {
                Console.Write("Orcs left: ");
                Console.WriteLine(string.Join(", ",waves));
            }
            else if (plates.Count > 0)
            {
                Console.Write("Plates left: ");
                Console.WriteLine(string.Join(", ", plates));
            }
        }
    }
}
