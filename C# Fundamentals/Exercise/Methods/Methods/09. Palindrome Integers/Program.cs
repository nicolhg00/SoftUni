using System;

namespace _09._Palindrome_Integers
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                string line = Console.ReadLine();
                if (line == "END")
                {
                    break;
                }
                Console.WriteLine(IsPalindrome(line));
            }
        }

        private static bool IsPalindrome(string line)
        {
            for (int i = 0; i < line.Length / 2; i++)
            {
                if (line[i] != line[line.Length - 1 - i])
                {
                    return false;
                }
            }
            return true;
        }
    }
}
