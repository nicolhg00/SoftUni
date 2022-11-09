using System;
using System.Collections.Generic;

namespace _4._Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, decimal> priceByProduct = new Dictionary<string, decimal>();
            Dictionary<string, int> quontityByProduct = new Dictionary<string, int>();

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "buy")
                {
                    break;
                }

                string[] parts = line.Split();

                string product = parts[0];
                decimal price = decimal.Parse(parts[1]);
                int quantity = int.Parse(parts[2]);

                if (priceByProduct.ContainsKey(product))
                {
                    quontityByProduct[product] += quantity;
                    priceByProduct[product] = price;
                }
                else
                {
                    priceByProduct.Add(product, price);
                    quontityByProduct.Add(product, quantity);
                }
            }

            foreach (var kvp in priceByProduct)
            {
                string product = kvp.Key;

                decimal price = kvp.Value;
                int quantity = quontityByProduct[product];
                decimal totalprice = quantity * price;

                Console.WriteLine($"{product} -> {totalprice:f2}");
            }
        }
    }
}
