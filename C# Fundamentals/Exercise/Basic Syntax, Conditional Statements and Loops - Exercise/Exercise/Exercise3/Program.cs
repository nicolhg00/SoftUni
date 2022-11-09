using System;

namespace Exercise3
{
    class Program
    {
        static void Main(string[] args)
        {
            int groupOfPeople = int.Parse(Console.ReadLine());
            string typeOfGroup = Console.ReadLine();
            string dayOfTheWeek = Console.ReadLine();
            double price = 0;

            switch (typeOfGroup)
            {
                case "Students":
                    if (dayOfTheWeek == "Friday")
                    {
                        price = 8.45;
                    }
                    else if (dayOfTheWeek =="Saturday")
                    {
                        price = 9.80;
                    }
                    else if (dayOfTheWeek == "Sunday")
                    {
                        price = 10.46;
                    }
                    if (groupOfPeople >= 20)
                    {
                        price -= price * 0.15;
                    }
                   
                    break;
                case "Business":
                    if (dayOfTheWeek == "Friday")
                    {
                        price = 10.90;
                    }
                    else if (dayOfTheWeek == "Saturday")
                    {
                        price = 15.60;
                    }
                    else if (dayOfTheWeek == "Sunday")
                    {
                        price = 16;
                    }
                    if (groupOfPeople >= 100)
                    {
                        groupOfPeople -= 10;
                    }
                    break;
                case "Regular":
                    if (dayOfTheWeek == "Friday")
                    {
                        price = 15;
                    }
                    else if (dayOfTheWeek == "Saturday")
                    {
                        price = 20;
                    }
                    else if (dayOfTheWeek == "Sunday")
                    {
                        price = 22.50;
                    }
                    if (groupOfPeople >= 10 && groupOfPeople <= 20)
                    {
                        price -= price * 0.05;
                    }
                    break;
                default:
                    break;
            }
            
            double totalPrice = price * groupOfPeople;
            
            Console.WriteLine($"Total price: {totalPrice:f2}");

        }
    }
}
