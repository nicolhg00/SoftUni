using System;

namespace exercise6
{
    class Program
    {
        static void Main(string[] args)
        {
            string input= Console.ReadLine();
            int minNum = int.MaxValue;
            while (input != "Stop")
            {
                int currentNumber = int.Parse(input);
                if (currentNumber < minNum)
                {
                    minNum = currentNumber;
                }
                input = Console.ReadLine();
            }
            Console.WriteLine(minNum);
        }
    }
}
