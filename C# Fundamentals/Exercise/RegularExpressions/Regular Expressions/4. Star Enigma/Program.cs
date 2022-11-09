using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _4._Star_Enigma
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Regex keyRegex = new Regex(@"[STARstar]");

            Regex regex = new Regex(@"^[^@\-!:>]*@(?<name>[A-Za-z]+)[^@\-!:>]*\:(?<population>\d+)[^@\-!:>]*!(?<type>[AD])![^@\-!:>]*->(?<soldiers>\d+)[^@\-!:>]*$");

            List<string> attacked = new List<string>();
            List<string> destroyed = new List<string>();
            for (int i = 0; i < n; i++)
            {
                string text = Console.ReadLine();

                int key = keyRegex.Matches(text).Count;

                string decryptedText = Decrypt(text, key);

                Match match = regex.Match(decryptedText);

                if (!match.Success)
                {
                    continue;
                }

                string name = match.Groups["name"].Value;
                string type = match.Groups["type"].Value;

                if (type == "A")
                {
                    attacked.Add(name);
                }
                else
                {
                    destroyed.Add(name);
                }

            }

            Console.WriteLine($"Attacked planets: {attacked.Count}");

            List<string> sortedAttacked = attacked.
                OrderBy(x => x)
                .ToList();

            foreach (var planet in sortedAttacked)
            {
                Console.WriteLine($"-> {planet}");
            }

            Console.WriteLine($"Destroyed planets: {destroyed.Count}");

            List<string> sortedDestoyed = destroyed
                .OrderBy(x => x)
                .ToList();
            foreach (var planet in sortedDestoyed)
            {
                Console.WriteLine($"-> {planet}");
            }

        }

        private static string Decrypt(string text, int key)
        {
            StringBuilder sb = new StringBuilder();

            foreach (var letter in text)
            {
                sb.Append((char)(letter - key));

            }
            return sb.ToString();
        }
    }
}
