using System;


namespace Scholarship
{
    class Program
    {
        static void Main(string[] args)
        {
            int floor = int.Parse(Console.ReadLine());
            int rooms = int.Parse(Console.ReadLine());
            int count = 0;
            for (int floorCount = 1; floorCount <= floor; floor--)
            {
                for (int roomCount = 0; roomCount < rooms; roomCount++)
                {
                    if (floor % 2 == 0)
                    {

                        if (floor < 1 || count < rooms)
                        {
                            count++;
                            Console.Write($"L{floor}{roomCount} ");
                        }
                        else
                        {
                            Console.Write($"O{floor}{roomCount} ");
                        }
                    }
                    else if (floor % 2 != 0)
                    {
                        if (floor < 1 || count < rooms)
                        {
                            count++;
                            Console.Write($"L{floor}{roomCount} ");
                        }
                        else
                        {
                            Console.Write($"A{floor}{roomCount} ");
                        }
                    }
                }
                Console.WriteLine();
            }

        }
    }
}