using System;

namespace _1._Valid_Username
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] usernames = Console.ReadLine()
                .Split(", ");

            foreach (var username in usernames)
            {
                if (IsValid(username))
                {
                    Console.WriteLine(username);
                }
            }
        }

        private static bool IsValid(string username)
        {
            return IsValidLenght(username) && ContainsValisSymbols(username);
        }

        private static bool ContainsValisSymbols(string username)
        {
            foreach (var symbol in username)
            {
                if (!char.IsLetterOrDigit(symbol) &&
                    symbol != '_' &&
                    symbol != '-')
                {
                    return false;
                }
            }
            return true;
        }

        private static bool IsValidLenght(string username)
        {
            return username.Length >= 3 && username.Length <= 26;
        }
    }
}
