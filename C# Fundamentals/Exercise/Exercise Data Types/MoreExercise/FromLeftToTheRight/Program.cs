using System;
using System.Numerics;

namespace FromLeftToTheRight
{
    class Program
    {
        static void Main(string[] args)
        {
            //????????????????????????
            int lines = int.Parse(Console.ReadLine());
            for (int i = 0; i < lines; i++)
            {
                int sumDigits = 0;
                string currLine = Console.ReadLine();
                string[] splitString = currLine.Split();
                int index = 1;

                if (BigInteger.Parse(splitString[0]) > BigInteger.Parse(splitString[1]));

                {
                    index = 0;
                }

                for (int j = 0; j < splitString[index].Length; j++)
                {
                    if (splitString[index][j] != '-')
                    {
                        sumDigits += int.Parse(splitString[index][j].ToString());

                    }
                }
                Console.WriteLine(sumDigits);
            }
        }
    }
}
