using System;
using System.Linq;

namespace Re_Volt
{
    class Program
    {
        static void Main(string[] args)
        {
            int sizeMatrix = int.Parse(Console.ReadLine());
            int countCommand = int.Parse(Console.ReadLine());
            char[][] matrix = new char[sizeMatrix][];

            int playerRow = 0;
            int playerCol = 0;
            for (int rows = 0; rows < sizeMatrix; rows++)
            {
                string command = Console.ReadLine();
                matrix[rows] = new char[command.Length];
                
                for (int cols = 0; cols < matrix[rows].Length; cols++)
                {
                    matrix[rows][cols] = command[cols];
                    if (matrix[rows][cols] == 'f')
                    {
                        playerRow = rows;
                        playerCol = cols;
                    }
                }
            }

            bool isWin = false;

            while (countCommand > 0)
            {
                string commands = Console.ReadLine();

                switch (commands)
                {
                    case "down":
                        if (playerRow + 1 == sizeMatrix)
                        {
                            matrix[playerRow][playerCol] = '-';
                            playerRow = 0;
                            break;
                        }
                        matrix[playerRow][playerCol] = '-';
                        playerRow++;
                        if (matrix[playerRow][playerCol] == 'B')
                        {
                            if (playerRow + 1 == sizeMatrix)
                            {
                                
                                playerRow = 0;
                                break;
                            }
                            playerRow++;
                        }
                        else if (matrix[playerRow][playerCol] == 'T')
                        {
                            if (playerRow - 1 < 0)
                            {
                               
                                playerRow = sizeMatrix - 1;
                                break;
                            }
                            playerRow--;
                        }
                        break;
                    case "up":
                        if (playerRow - 1< 0)
                        {
                            matrix[playerRow][playerCol] = '-';
                            playerRow = sizeMatrix - 1;
                            break;
                        }
                        matrix[playerRow][playerCol] = '-';
                        playerRow--;
                        if (matrix[playerRow][playerCol] == 'B')
                        {
                            if (playerRow - 1 < 0)
                            {
                                
                                playerRow = sizeMatrix - 1;
                                break;
                            }
                            playerRow--;
                        }
                        else if (matrix[playerRow][playerCol] == 'T')
                        {
                            if (playerRow + 1 == sizeMatrix)
                            {
                                
                                playerRow = 0;
                                break;
                            }
                            playerRow++;
                        }
                        break;
                    case "left":
                        if (playerCol - 1 < 0)
                        {
                            matrix[playerRow][playerCol] = '-';
                            playerCol = sizeMatrix - 1 ;
                            break;
                        }
                        matrix[playerRow][playerCol] = '-';
                        playerCol--;
                        if (matrix[playerRow][playerCol] == 'B')
                        {
                            if (playerCol - 1 < 0)
                            {
                                
                                playerCol = sizeMatrix - 1;
                                break;
                            }
                            playerCol--;
                        }
                        else if (matrix[playerRow][playerCol] == 'T')
                        {
                            if (playerCol + 1 == matrix[playerRow].Length)
                            {
                                
                                playerRow = 0;
                                break;
                            }

                            playerCol++;
                        }
                        break;
                    case "right":
                        if (playerCol + 1 == matrix[playerRow].Length)
                        {
                            matrix[playerRow][playerCol] = '-';
                            playerRow = 0;
                            break;
                        }
                        matrix[playerRow][playerCol] = '-';
                        playerCol++;
                        if (matrix[playerRow][playerCol] == 'B')
                        {
                            if (playerCol + 1 == matrix[playerRow].Length)
                            {
                                
                                playerRow = 0;
                                break;
                            }
                           
                            playerCol++;
                        }
                        else if (matrix[playerRow][playerCol] == 'T')
                        {
                            if (playerCol - 1 < 0)
                            {
                                
                                playerCol = sizeMatrix - 1;
                                break;
                            }
                            playerCol--;
                        }
                        break;
                    default:
                        break;
                }
                if (matrix[playerRow][playerCol] == 'F')
                {
                    isWin = true;
                    matrix[playerRow][playerCol] = 'f';
                    break;
                }
                
                matrix[playerRow][playerCol] = 'f';
                countCommand--;
            }
            if (isWin)
            {
                Console.WriteLine("Player won!");
            }
            else
            {
                Console.WriteLine("Player lost!");
            }

            foreach (var item in matrix)
            {
                Console.WriteLine(string.Join("", item));
            }
        }
    }
}
