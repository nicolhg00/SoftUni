using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BakeryOpenning
{
    public class Bakery
    {
        private List<Employee> data;
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Count => data.Count;

        public Bakery(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            data = new List<Employee>();
        }

        public void Add(Employee employee)
        {
            if (Capacity > data.Count)
            {
                data.Add(employee);
            }
        }

        public bool Remove(string name)
        {
            bool isNameExists = data.Exists(n => n.Name == name);
            if (isNameExists)
            {
                data.Remove(data.FirstOrDefault(n => n.Name == name));
            }
            return isNameExists;
        }

        public Employee GetOldestEmployee()
        {
            var oldestEmployee = data.OrderByDescending(x => x.Age).FirstOrDefault();
            return oldestEmployee;
        }

        public Employee GetEmployee(string name)
        {
            Employee findEmployee = data.FirstOrDefault(n => n.Name == name);
            return findEmployee;
        }



        public string Report()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Employees working at Bakery {Name}:");

            foreach (var item in data)
            {
                sb.AppendLine($"{item.ToString()}");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
