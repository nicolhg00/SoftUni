using System;

namespace exercise2
{
    class Program
    {
        static void Main(string[] args)
        {
            int start = int.Parse(Console.ReadLine());
            int end = int.Parse(Console.ReadLine());

            for (int i = start; i <= end; i++)
            {
                string numAsText = i.ToString();
                int oddSum = 0;
                int evenSum = 0;
                for (int index = 0; index < numAsText.Length; index++)
                {
                    int num = int.Parse(numAsText[index].ToString());

                    if (index % 2 == 0)
                    {
                        evenSum += num;
                    }
                    else
                    {
                        oddSum += num;
                    }
                }
                if (oddSum == evenSum)
                {
                    Console.Write($"{i} ");
                }
            }
        }
    }
}
