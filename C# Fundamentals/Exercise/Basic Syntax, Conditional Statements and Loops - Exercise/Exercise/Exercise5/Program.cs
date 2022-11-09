using System;
using System.Linq;

namespace Exercise5
{
    class Program
    {
        static void Main(string[] args)
        {
            string username = Console.ReadLine();

            string password = string.Concat(username.Reverse());
            int couter = 0;
            bool isLogedIn = false;
            while (!isLogedIn)
            {
                string input = Console.ReadLine();

                if (input == password)
                {
                    Console.WriteLine($"User {username} logged in.");
                    isLogedIn = true;
                }
                else
                {
                    couter++;
                    if (couter == 4)
                    {
                        Console.WriteLine($"User {username} blocked!");
                        break;
                    }
                    else
                    {
                        Console.WriteLine($"Incorrect password. Try again.");
                    }
                }

            }
        }
    }
}
