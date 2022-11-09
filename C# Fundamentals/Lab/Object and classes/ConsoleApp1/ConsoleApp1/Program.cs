using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine()
               .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            Random rnd = new Random();

            for (int i = 0; i < words.Length; i++)
            {
                int pos = rnd.Next(words.Length);

                string word = words[i];
                words[i] = words[pos];
                words[pos] = word;
            }

            Console.Write(string.Join('\n', words));
        }
    }
}
