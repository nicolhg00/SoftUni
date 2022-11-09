using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheRace
{
    public class Race
    {
        private HashSet<Racer> data;
        public List<Racer> Racers { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public Racer oldestRacer { get; set; }
        public Racer fastestRacer { get; set; }
        public int Count => data.Count;

        public Race(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            data = new HashSet<Racer>();
        }


        public void Add(Racer Racer)
        {
            if (data.Count < Capacity)
            {
                data.Add(Racer);
            }
        }

        public bool Remove(string name)
        {
            bool isNameExists = data.Any(n => n.Name == name);
            if (isNameExists)
            {
                data.Remove(data.FirstOrDefault(n => n.Name == name));
            }
            return isNameExists;
        }

        public Racer GetOldestRacer()
        {
            var sortRacer = data.OrderBy(r => r.Age).ToArray();
            Racer oldestRacer = sortRacer[sortRacer.Length];
            return oldestRacer;
        }

        public Racer GetRacer(string name)
        {
            Racer findRacer = data.FirstOrDefault(n => n.Name == name);
            return findRacer;
        }

        public Racer GetFastestRacer()
        {
            var sortSpeed = data.OrderBy(s => s.Car.Speed).ToArray();
            Racer highestSpeed = sortSpeed[sortSpeed.Length];
            return highestSpeed;
        }
        public int GetCount()
        {
            return data.Count;
        }
        public string Report()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Racers participating at {Name}:");

            foreach (var item in data)
            {
                sb.AppendLine($"{item}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
