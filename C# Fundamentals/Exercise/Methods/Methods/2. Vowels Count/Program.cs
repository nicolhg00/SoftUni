using System;

namespace _2._Vowels_Count
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            int vowelsCount = GetVowelsCount(text);
            Console.WriteLine(vowelsCount);
        }

        private static int GetVowelsCount(string text)
        {
            int couter = 0;

            text = text.ToLower();
            foreach (char letter in text)
            {
                if (letter == 'a' ||
                    letter == 'o' ||
                    letter == 'e' ||
                    letter == 'y' ||
                    letter == 'u' ||
                    letter == 'i' )
                {
                    couter++;
                }
            }
            return couter;
        }
    }
}
