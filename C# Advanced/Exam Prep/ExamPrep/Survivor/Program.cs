using System;
using System.Linq;

namespace Survivor
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            char[][] matrix = new char[rows][];
            int tokenCollected = 0;
            int tokenOpponents = 0;
            for (int row = 0; row < rows; row++)
            {
                matrix[row] = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();
            }

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "Gong")
                {
                    break;
                }
                string[] commands = input.Split();
                string command = commands[0];
                int row = int.Parse(commands[1]);
                int col = int.Parse(commands[2]);

                if (row >= 0 && row < rows && col >= 0 && col < matrix[row].Length)
                {
                    if (command == "Find")
                    {
                        if (matrix[row][col] == 'T')
                        {
                            tokenCollected++;
                            matrix[row][col] = '-';

                        }
                    }

                    else if (command == "Opponent")
                    {
                        string direction = commands[3];
                        if (matrix[row][col] == 'T')
                        {
                            tokenOpponents++;
                            matrix[row][col] = '-';
                        }
                        switch (direction)
                        {
                            case "up":
                                for (int i = 1; i <= 3; i++)
                                {
                                    if (row - 1 >= 0 && row - 1 < rows)
                                    {
                                        if (matrix[row - i][col] == 'T')
                                        {
                                            tokenOpponents++;
                                            matrix[row - i][col] = '-';
                                        }
                                    }
                                }
                                break;

                            case "down":
                                for (int j = 1; j <= 3; j++)
                                {
                                    if (row + j >= 0 && row + j < rows)
                                    {
                                        if (matrix[row + j][col] == 'T')
                                        {
                                            tokenOpponents++;
                                            matrix[row + j][col] = '-';
                                        }
                                    }
                                }
                                break;

                            case "left":
                                for (int k = 1; k <= 3; k++)
                                {
                                    if (col - k >= 0 && col - k < matrix[row].Length)
                                    {
                                        if (matrix[row][col - k] == 'T')
                                        {
                                            tokenOpponents++;
                                            matrix[row][col - k] = '-';
                                        }
                                    }
                                }
                                break;

                            case "right":
                                for (int l = 1; l <= 3; l++)
                                {
                                    if (col + l >= 0 && col + l < matrix[row].Length)
                                    {
                                        if (matrix[row][col + l] == 'T')
                                        {
                                            tokenOpponents++;
                                            matrix[row][col + l] = '-';
                                        }
                                    }
                                }
                                break;
                            default:
                                break;
                        }
                    }
                }

            }
            foreach (var item in matrix)
            {
                Console.WriteLine(string.Join(" ", item));
            }

            Console.WriteLine($"Collected tokens: {tokenCollected}");
            Console.WriteLine($"Opponent's tokens: {tokenOpponents}");
        }
    }
}
