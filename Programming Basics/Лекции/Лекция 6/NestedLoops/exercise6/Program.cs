using System;

namespace exercise6
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int students = 0;
            int kids = 0;
            int standard = 0;
            int totalTickets = 0;
            while (input != "Finish")
            {
                int capacity = int.Parse(Console.ReadLine());
                int tickets = 0;
                string ticketType = Console.ReadLine();
                while (ticketType != "End")
                {
                    tickets++;
                    switch (ticketType)
                    {
                        case "kid":
                            kids++;
                            break;

                        case "student":
                            students++;
                            break;

                        case "standard":
                            standard++;
                            break;

                        default:
                            break;
                    }
                    if (tickets >= capacity)
                    {
                        break;
                    }
                    ticketType = Console.ReadLine();
                }
                totalTickets += tickets;
                Console.WriteLine($"{input} - {1.0 * tickets / capacity*100:f2}% full.");

                input = Console.ReadLine();
            }
            Console.WriteLine($"Total tickets: {totalTickets}");
            Console.WriteLine($"{1.0 * students / totalTickets*100:f2}% student tickets.");
            Console.WriteLine($"{1.0 * standard / totalTickets * 100:f2}% standard tickets.");
            Console.WriteLine($"{1.0 * kids / totalTickets * 100:f2}% kids tickets.");
        }
    }
}
