using System;

namespace exercise1
{
    class Program
    {
        static void Main(string[] args)
        {
            int endNumber = int.Parse(Console.ReadLine());
            int num = 1;
            for (int row = 1; row <= endNumber; row++)
            {
                for (int col = 1; col <= row; col++)
                {
                    Console.Write($"{num++} ");
                    if (num > endNumber)
                    {
                        break;
                    }
                }
                if (num > endNumber)
                {
                    break;
                }
                Console.WriteLine();
            }

             
        }
    }
}
