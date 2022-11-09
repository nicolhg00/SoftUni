using System;
using System.Collections.Generic;
using System.Text;

namespace Guild
{
    public class Player
    {
        public string Name { get; set; }
        public string Class { get; set; }
        public string Rank { get; set; }
        public string Description { get; set; }

        public Player(string name, string clas)
        {
            Name = name;
            Class = clas;
            Rank = "Trial";
            Description = "n/a";
        }

        public override string ToString()
        {
            return $"Player {Name}: {Class}\r\n" +
                   $"Rank: {Rank}\r\n" +
                   $"Description: {Description}";

        }
    }
}
