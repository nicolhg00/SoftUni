using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingSpree
{
    public class Person
    {
        private string name;
        private int money;
        private List<Product> bag = new List<Product>();
        public string Name
        {
            get { return name; }
            set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }

                name = value;
            }
        }

        public int Money

        {
            get { return money; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }

                money = value;
            }

        }


        public List<Product> Bag
        {
            get { return bag; }
            set { bag = value; }
        }

        public Person(string name, int money)
        {
            Name = name;
            Money = money;
        }

        public string BuyProduct(Product product)
        {
            if (product.Cost <= Money)
            {
                Bag.Add(product);
                Money -= product.Cost;
                return $"{Name} bought {product.Name}";
            }
            else
            {
                return $"{Name} can't afford {product.Name}";
            }
        }

    }
}
