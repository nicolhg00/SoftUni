using System;
using System.Collections.Generic;
using System.Linq;

namespace Raiding
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int numberOfHeroes = int.Parse(Console.ReadLine());
            List<BaseHero> heroes = new List<BaseHero>();

            while(heroes.Count != numberOfHeroes)
            {
                try
                {
                    string name = Console.ReadLine();
                    string heroType = Console.ReadLine();

                    if (heroType is "Paladin")
                    {
                        heroes.Add(new Paladin(name));
                    }
                    else if (heroType is "Druid")
                    {
                        heroes.Add(new Druid(name));
                    }
                    else if (heroType is "Rogue")
                    {
                        heroes.Add(new Rogue(name));
                    }
                    else if (heroType is "Warrior")
                    {
                        heroes.Add(new Warrior(name));
                    }
                    else
                    {
                        throw new ArgumentException("Invalid hero");
                    }

                }
                catch (ArgumentException ex)
                {

                    Console.WriteLine(ex.Message);
                }
            }

            int bossPower = int.Parse(Console.ReadLine());

            foreach (var hero in heroes)
            {
                Console.WriteLine(hero.CastAbility());
            }

            int heroesPower = heroes.Sum(x => x.Power);

            if (heroesPower >= bossPower)
            {
                Console.WriteLine("Victory!");
            }
            else
            {
                Console.WriteLine("Defeat...");
            }
        }
    }
}
