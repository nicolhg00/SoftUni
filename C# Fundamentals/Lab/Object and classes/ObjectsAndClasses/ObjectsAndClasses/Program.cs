using System;

namespace ObjectsAndClasses
{
    class Program
    {
        static void Main(string[] args)
        {
            Dog rufus = new Dog()
            {
                Age = 5,
                Breed = "corgi",
                Name = "Rufus"
            };

            Console.WriteLine($"{rufus.Name} is a {rufus.Breed} and is {rufus.Age} yaers old");
        }
    }
}
