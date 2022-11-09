using System;
using System.Collections.Generic;

namespace _6.Wardrobe
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, Dictionary<string, int>> wardrobe = new Dictionary<string, Dictionary<string, int>>();
         
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(" -> ",StringSplitOptions.RemoveEmptyEntries);
                string curColer = input[0];
                string[] clothes = input[1].Split(",");

                if (!wardrobe.ContainsKey(curColer))
                {
                    wardrobe.Add(curColer, new Dictionary<string, int>());
                }

                for (int cloth = 0; cloth < clothes.Length; cloth++)
                {
                    if (!wardrobe[curColer].ContainsKey(clothes[cloth]))
                    {
                        wardrobe[curColer].Add(clothes[cloth], 0);
                    }

                    wardrobe[curColer][clothes[cloth]]++;
                }
            }

            string[] clothesToFind = Console.ReadLine().Split();
            string colorToFind = clothesToFind[0];
            string clothToFind = clothesToFind[1];

            foreach (var kvp in wardrobe)
            {
                Console.WriteLine($"{kvp.Key} clothes:");
                foreach (var clothing in kvp.Value)
                {
                    if (colorToFind == kvp.Key && clothToFind == clothing.Key)
                    {
                        Console.WriteLine($"* {clothing.Key} - {clothing.Value} (found!)");
                        continue;
                    }
                    Console.WriteLine($"* {clothing.Key} - {clothing.Value} ");
                }
            }
        }
    }
}
