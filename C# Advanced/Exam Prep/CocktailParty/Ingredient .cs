using System;
using System.Collections.Generic;
using System.Text;

namespace CocktailParty
{
    public class Ingredient
    {
        public string Name { get; set; }
        public int Alcohol { get; set; }
        public int Quantity { get; set; }
        public bool Count { get; internal set; }

        public Ingredient(string name, int alcohol, int quantity)
        {
            Name = name;
            Alcohol = alcohol;
            Quantity = quantity;
        }
        public override string ToString()
        {
            return $"Ingredient: {Name}\r\n" +
                $"Quantity: {Quantity}\r\n" +
                $"Alcohol: {Alcohol}";
        }

    }
}
