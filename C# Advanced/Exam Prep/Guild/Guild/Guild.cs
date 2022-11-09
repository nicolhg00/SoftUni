using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Guild
{
    public class Guild
    {
        List<Player> roster;
        public string Name { get; set; }
        public int Capacity { get; }

        public int Count { get { return this.roster.Count; } }
        public Guild(string name,int capacity)
        {
            Name = name;
            Capacity = capacity;
            roster = new List<Player>();
        }
        public void AddPlayer(Player player)
        {
            if (Capacity >= roster.Count)
            {
                roster.Add(player);
            }
        }
        public bool RemovePlayer(string name)
        {
            bool isPlayerExists = roster.Exists(r => r.Name == name);
            if (isPlayerExists)
            {
                roster.Remove(roster.FirstOrDefault(r => r.Name == name));
            }
            return isPlayerExists;
        }

        public void PromotePlayer(string name)
        {
            if (roster.Any(m => m.Name == name))
            {
                Player myPromotedPlayer = roster.Where(x => x.Name == name).FirstOrDefault();
                myPromotedPlayer.Rank = "Member";
            }
        }

        public void DemotePlayer(string name)
        {
            if (roster.Any(m => m.Name == name))
            {
                Player myDemotePlayer = roster.Where(x => x.Name == name).FirstOrDefault();
                myDemotePlayer.Rank = "Trial";
            }
        }

        public Player[] KickPlayersByClass(string classy)
        {
            List<Player> myListTemp = new List<Player>();
            foreach (var player in this.roster)
            {
                if (player.Class == classy)
                {
                    myListTemp.Add(player);
                }
            }
            Player[] myArrayToReturn = myListTemp.ToArray();
            this.roster = this.roster.Where(x => x.Class != classy).ToList();

            return myArrayToReturn;
        }

       public string Report()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Players in the guild: {this.Name}");

            foreach (var player in roster)
            {
                sb.AppendLine($"{player}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
