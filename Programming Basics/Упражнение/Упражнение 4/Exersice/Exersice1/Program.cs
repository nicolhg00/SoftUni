using System;

namespace Exersice1
{
    class Program
    {
        static void Main(string[] args)
        {

            for (int i = 1; i <= 1000 ; i++)
            {
                string numAsTex = i.ToString();
                int len = numAsTex.Length;
                char symbol = numAsTex[len - 1];
                Console.WriteLine(numAsTex);
                if (symbol == '7')
                {
                    Console.WriteLine(numAsTex);
                }
            }
        }
    }
}
