using System;
using System.Linq;

namespace _2.Warship
{
    class Program
    {
        static void Main(string[] args)
        {
            int fieldSize = int.Parse(Console.ReadLine());

            string[] allAttackCoordinates = Console.ReadLine()
                .Split(',', StringSplitOptions.RemoveEmptyEntries);

            int rows = fieldSize;
            int cols = fieldSize;

            char[,] field = new char[rows, cols];

            int firstPlayerShips = 0;
            int secondPlayerShips = 0;

            for (int row = 0; row < rows; row++)
            {
                char[] fieldLine = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();

                for (int col = 0; col < cols; col++)
                {
                    field[row, col] = fieldLine[col];

                    if (fieldLine[col] == '<')
                    {
                        firstPlayerShips++;
                    }
                    else if (fieldLine[col] == '>')
                    {
                        secondPlayerShips++;
                    }
                }
            }

            int firstRemainingShips = firstPlayerShips;
            int secondRemainingShips = secondPlayerShips;

            bool gameIsWon = false;
            string winner = string.Empty;

            for (int i = 0; i < allAttackCoordinates.Length; i++)
            {
                int[] attack = allAttackCoordinates[i]
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                int attackRow = attack[0];
                int attackCol = attack[1];

                if (attackRow < 0 || attackRow >= rows || attackCol < 0 || attackCol >= cols)
                {
                    continue;
                }

                if (field[attackRow, attackCol] == '<')
                {
                    firstRemainingShips--;
                    field[attackRow, attackCol] = 'X';
                }
                else if (field[attackRow, attackCol] == '>')
                {
                    secondRemainingShips--;
                    field[attackRow, attackCol] = 'X';
                }
                else if (field[attackRow, attackCol] == '#')
                {
                    for (int row = attackRow - 1; row <= attackRow + 1; row++)
                    {
                        for (int col = attackCol - 1; col <= attackCol + 1; col++)
                        {
                            if (IsWithinField(field, row, col))
                            {
                                if (IsFirstPlayerShip(field, row, col))
                                {
                                    firstRemainingShips--;
                                    field[row, col] = 'X';
                                }
                                else if (IsSecondPlayerShip(field, row, col))
                                {
                                    secondRemainingShips--;
                                    field[row, col] = 'X';
                                }
                            }
                        }
                    }
                }

                if (firstRemainingShips == 0)
                {
                    gameIsWon = true;
                    winner = "Two";
                    break;
                }
                else if (secondRemainingShips == 0)
                {
                    gameIsWon = true;
                    winner = "One";
                    break;
                }
            }

            int totalDestroyedShips = (firstPlayerShips - firstRemainingShips) + (secondPlayerShips - secondRemainingShips);

            if (gameIsWon)
            {
                Console.WriteLine($"Player {winner} has won the game! {totalDestroyedShips} ships have been sunk in the battle.");
            }
            else
            {
                Console.WriteLine($"It's a draw! Player One has {firstRemainingShips} ships left. Player Two has {secondRemainingShips} ships left.");
            }
        }

        public static bool IsFirstPlayerShip(char[,] field, int row, int col)
        {
            return field[row, col] == '<';
        }

        public static bool IsSecondPlayerShip(char[,] field, int row, int col)
        {
            return field[row, col] == '>';
        }

        public static bool IsWithinField(char[,] field, int row, int col)
        {
            return row >= 0 && row < field.GetLength(0) && col >= 0 && col < field.GetLength(1);
        }
    }
}
