using System;

namespace exercise3
{
    class Program
    {
        static void Main(string[] args)
        {
            string month = Console.ReadLine();
            double spendTime = double.Parse(Console.ReadLine());
            int numOfPeople = int.Parse(Console.ReadLine());
            string timeOfDay = Console.ReadLine();
            double priceForHour = 0;

            switch (month)
            {
                case "march":
                case "april":
                case "may":
                    switch (timeOfDay)
                    {
                        case "day":
                            priceForHour = 10.50;
                            break;
                        case "night":
                            priceForHour = 8.40;
                            break;
                        default:
                            break;
                    }
                    break;
                case "june":
                case "july":
                case "august":
                    switch (timeOfDay)
                    {
                        case "day":
                            priceForHour = 12.60;
                            break;
                        case "night":
                            priceForHour = 10.20;
                            break;
                        default:
                            break;
                    }
                    break;
                default:
                    break;
            }
            if (numOfPeople >= 4)
            {
                priceForHour = priceForHour * 0.90;  
            }
            if (spendTime >= 5)
            {
               priceForHour = priceForHour * 0.50;
            }
            double totalPrice = (priceForHour * numOfPeople) * spendTime;
            Console.WriteLine($"Price per person for one hour: {priceForHour:f2}");
            Console.WriteLine($"Total cost of the visit: {totalPrice:f2}");
        }
    }
}
