using System;

namespace exercise5
{
    class Program
    {
        static void Main(string[] args)
        {
            //1. Read the input

            string name = Console.ReadLine();
            //2. Create a variable for the score
            int score = 301;

            //3. Create two veriables for successful an unsuccessful schots
            int successfulShots = 0;
            int unsuccessfulShots = 0;
            string area = Console.ReadLine();

            //4. While loop until "Retire"
            while (area != "Retire")
            {
                //4.1 Read the info about the shot
                int initialPoints = int.Parse(Console.ReadLine());
                int currentPoints = 0;

                //Check the area and calculate the points 
                switch (area)
                {
                    case "Single":
                        currentPoints = initialPoints;
                        break;
                    case "Double":
                        currentPoints = initialPoints * 2;
                        break;
                    case "Triple":
                        currentPoints = initialPoints * 3;
                        break;
                }
                
                //4.2 Check whether the shot was successful or not
                //4.3 If successful -> successful++, score -= currentScore
                if (score - currentPoints >= 0)
                {
                    successfulShots++;
                    score -= currentPoints;
                }
                

                //4.4 If unsuccessful (Else)-> unsuccessful++
                else
                {
                    unsuccessfulShots++;
                }
                //4.5 Check if the person wins -> break;
                if (score == 0)
                {
                    break;
                }
                area = Console.ReadLine();
            }

            if (area == "Retire")
            {
                Console.WriteLine($"{name} retired after {unsuccessfulShots} unsuccessful shots.");
            }
            else
            {
                Console.WriteLine($"{name} won the leg with {successfulShots} shots.");
            }


        }
    }
}
