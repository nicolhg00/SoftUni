using System;
using System.Text.RegularExpressions;

namespace Emoji_Detector
{
    class Program
    {
        static void Main(string[] args)
        {
            Regex digitsReget = new Regex(@"\d");
            Regex emojiRegex= new Regex(@"(::([A-Z][a-z]{2,})::)|(\*\*([A-Z][a-z]{2,})\*\*)");

            string text = Console.ReadLine();

            MatchCollection allDigits = digitsReget.Matches(text);

            long threshold = CalculateTrashold(allDigits);

            Console.WriteLine($"Cool threshold: {threshold}");

            MatchCollection emojiMatches = emojiRegex.Matches(text);

            Console.WriteLine($"{emojiMatches.Count} emoji found in the text. The cool ones are:");
            foreach (Match emojiMatch in emojiMatches)
            {
                string emojiText = emojiMatch.Groups[2].Value;

                if (string.IsNullOrEmpty(emojiText))
                {
                    emojiText = emojiMatch.Groups[4].Value;
                }

                long coolness = GetAsciiSum(emojiText);

                if (coolness > threshold)
                {
                    Console.WriteLine(emojiMatch.Value);
                }
            }
        }

        private static long GetAsciiSum(string text)
        {
            long result = 0;
            foreach (char letter in text)
            {
                result += letter;
            }
            return result;
        }

        private static long CalculateTrashold(MatchCollection digits)
        {
            long result = 1;
            foreach (Match digit in digits)
            {
                result += int.Parse(digit.Value);
            }
            return result;
        }
    }
}
