using System;
using System.Linq;

namespace _2.Garden
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] n = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            int isRow = n[0];
            int isCol = n[1];
            int[,] garden = new int[isRow, isCol];

            for (int row = 0; row < isRow; row++)
            {
                for (int col = 0; col < isCol; col++)
                {
                    garden[row, col] = 0;
                }
            }

            string tokens = Console.ReadLine();
            while (tokens != "Bloom Bloom Plow")
            {
                int row = int.Parse(tokens[0].ToString());
                int col = int.Parse(tokens[2].ToString());

                if (row > isRow || row < 0 && col > isCol || col < 0)
                {
                    Console.WriteLine("Invalid coordinates.");
                    tokens = Console.ReadLine();
                    continue;
                }

                for (int i = 0; i < isRow; i++)
                {
                    garden[row, i]++;
                }
                for (int j = 0; j < isCol; j++)
                {
                    garden[j, col]++;
                }
                garden[row, col]--;
                tokens = Console.ReadLine();
            }

            for (int row = 0; row < isRow; row++)
            {
                for (int col = 0; col < isCol; col++)
                {
                    Console.Write(garden[row,col] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
