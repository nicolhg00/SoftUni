﻿using System;
using System.Collections.Generic;

namespace ComparingObjects
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Person> persons = new List<Person>();
            while (true)
            {
                var tokens = Console.ReadLine().Split();

                if (tokens[0] == "END")
                {
                    break;
                }
                persons.Add(new Person(tokens[0], int.Parse(tokens[1]), tokens[2]));
            }

            var index = int.Parse(Console.ReadLine()) - 1;
            var equal = 0;
            var NotEqual = 0;

            foreach (Person person in persons)
            {
                if (persons[index].CompareTo(person) == 0)
                {
                    equal++;
                }
                else
                {
                    NotEqual++;
                }
            }
            if (equal <= 1)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                Console.WriteLine($"{equal} {NotEqual} {persons.Count}");
            }
        }
    }
}
