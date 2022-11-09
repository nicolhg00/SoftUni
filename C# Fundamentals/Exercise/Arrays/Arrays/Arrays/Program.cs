using System;

namespace Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] firstArray = Console.ReadLine().Split();
            string[] secondArray = Console.ReadLine().Split();

            foreach (var firstElement in secondArray)
            {
                foreach (var secondElemnt in firstArray)
                {
                    if (firstElement == secondElemnt)
                    {
                        Console.Write($"{firstElement} ");
                    }

                }
            }
        }
    }
}
