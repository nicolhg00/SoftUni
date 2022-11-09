using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SkiRental
{
    public class SkiRental
    {
         List<Ski> data;
        public string Name { get; set; }
        public int Capacity { get; set; }

        public int Count => data.Count;

        public SkiRental(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            data = new List<Ski>();
        }
        public void Add(Ski ski)
        {
            if (Capacity > data.Count)
            {
                data.Add(ski);
            }
        }

        public bool Remove(string manufacturer, string model)
        {
            bool isExists = data.Exists(x => x.Manufacturer == manufacturer && x.Model == model);
            if (isExists)
            {
                data.Remove(data.FirstOrDefault(x => x.Manufacturer == manufacturer && x.Model == model));
            }
            return isExists;
        }

        public Ski GetNewestSki()
        {
           
            Ski findNewest = data.OrderByDescending(n => n.Year).FirstOrDefault();
            return findNewest;
        }

        public Ski GetSki(string manufacturer, string model)
        {
            Ski findManufacturer = data.FirstOrDefault(x => x.Manufacturer == manufacturer && x.Model == model);
            return findManufacturer;
        }

        public string GetStatistics()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"The skis stored in {Name}:");

            foreach (var item in data)
            {
                sb.AppendLine($"{item.ToString()}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
