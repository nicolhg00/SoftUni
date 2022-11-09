using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public class Animal
    {
        public int Age { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }

        public Animal(int age, string name, string gender)
        {
            Age = age;
            Name = name;
            Gender = gender;
        }
    }
}
