using System;

namespace exercise4
{
    class Program
    {
        static void Main(string[] args)
        {
            int start = int.Parse(Console.ReadLine());
            int end = int.Parse(Console.ReadLine());
            int magic = int.Parse(Console.ReadLine());
            int counter = 0;
            bool flag = false;
            for (int num1 = start; num1 <= end; num1++)
            {
                for (int num2 = start; num2 <= end; num2++)
                {
                    counter++;
                    if (num1 + num2 == magic)
                    {
                        Console.WriteLine($"Combination N:{counter} ({num1} + {num2} = {magic})");
                        flag = true;
                        break;
                    }

                }
                if (flag)
                {
                    break;
                }
            }
            if (!flag)
            {
                Console.WriteLine($"{counter} combinations - neither equals {magic}");
            }



        }
    }
}
