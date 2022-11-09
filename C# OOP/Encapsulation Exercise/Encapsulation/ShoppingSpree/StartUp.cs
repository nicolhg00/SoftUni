using System;
using System.Collections.Generic;

namespace ShoppingSpree
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] inputPeople = Console.ReadLine()
                .Split(';', StringSplitOptions.RemoveEmptyEntries);
            string[] inputProducts = Console.ReadLine()
                .Split(';', StringSplitOptions.RemoveEmptyEntries);

            Dictionary<string, Person> people = new Dictionary<string, Person>();
            Dictionary<string, Product> products = new Dictionary<string, Product>();

            foreach (var currPerson in inputPeople)
            {
                try
                {
                    string[] info = currPerson
                    .Split('=', StringSplitOptions.RemoveEmptyEntries);

                    Person person = new Person(info[0], int.Parse(info[1]));
                    people.Add(info[0], person);
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                    Environment.Exit(0);
                }
            }

            foreach (var currProduct in inputProducts)
            {
                try
                {
                    string[] info = currProduct
                    .Split('=', StringSplitOptions.RemoveEmptyEntries);

                    Product product = new Product(info[0], int.Parse(info[1]));
                    products.Add(info[0], product);
                }
                catch (ArgumentException ae)
                {

                    Console.WriteLine(ae.Message);
                    Environment.Exit(0);
                }
            }

            string buyCommand = Console.ReadLine();

            while (buyCommand != "END" && people.Count != 0)
            {
                string[] tokens = buyCommand
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string personName = tokens[0];
                string productName = tokens[1];

                if (people.ContainsKey(personName))
                {
                    Console.WriteLine(people[personName].BuyProduct(products[productName]));
                }

                buyCommand = Console.ReadLine();
            }

            foreach (var person in people)
            {
                if (person.Value.Bag.Count == 0)
                {
                    Console.WriteLine($"{person.Key} - Nothing bought");
                }
                else
                {
                    Console.WriteLine($"{person.Key} - {string.Join(", ", person.Value.Bag)}");
                }
            }
        }
    }
}