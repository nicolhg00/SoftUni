using System;

namespace exercise6
{
    class Program
    {
        static void Main(string[] args)
        {
            //1. Read the input - the num of clients
            int numOfCLients = int.Parse(Console.ReadLine());

            //2. For Loop for each client
            double totalPrice = 0;
            for (int i = 0; i < numOfCLients; i++)
            {
                //2.1 While Loop for the purcheses of each clients
                //2.2 Keep track of the total price
                double currentTotal = 0;
                int countOfItems = 0;
                string purchese = Console.ReadLine();
                while (purchese != "Finish")
                {
                    countOfItems++;
                    switch (purchese)
                    {
                        case "basket":
                            currentTotal += 1.50;
                            break;
                        case "wreath":
                            currentTotal += 3.80;
                            break;
                        case "chocolate bunny":
                            currentTotal += 7;
                            break;
                    }
                    purchese = Console.ReadLine();
                }

                //3. Check if the num of items is even -> if yes - 20%
                if (countOfItems %2==0)
                {
                    currentTotal -= currentTotal * 0.20;
                }
                totalPrice += currentTotal;
                Console.WriteLine($"You purchased {countOfItems} items for {currentTotal:f2} leva.");
            }


            Console.WriteLine($"Average bill per client is: {totalPrice / numOfCLients:f2} leva.");
          
        }
    }
}
