using System;

namespace exercise3
{
    class Program
    {
        static void Main(string[] args)
        {
            int primeSum = 0;
            int notPrimeSum = 0;
            string input = Console.ReadLine();
            while (input != "stop")
            {
                int num = int.Parse(input);
                if (num < 0)
                {
                    Console.WriteLine("Number is negative.");
                }
               else if (num <= 1)
                {
                    notPrimeSum += num;
                }
                else if (num == 2)
                {
                    primeSum += num;
                }
                else if (num % 2 ==0)
                {
                    notPrimeSum += num;
                }
                else
                {
                    int bound = (int)Math.Floor(Math.Sqrt(num));
                    bool isPrime = true;
                    for (int i = 3; i <= bound; i++)
                    {

                        if (num % i == 0)
                        {
                            isPrime = false;
                            break;
                        }
                    }
                    if (isPrime)
                    {
                        primeSum += num;
                    }
                    else
                    {
                        notPrimeSum += num;
                    }
                }


                input = Console.ReadLine();
            }
            Console.WriteLine($"Sum of all prime numbers is: {primeSum}");
            Console.WriteLine($"Sum of all non prime numbers is: {notPrimeSum}");
        }
    }
}
