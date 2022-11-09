﻿using MilitaryElite.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Models
{
    public abstract class Soldier : ISoldier
    {
        public Soldier(int id, string firstName, string lastName)
        {
           this.Id = id;
           this.FirstName = firstName;
           this.LastName = lastName;
        }

        public int Id { get; }

        public string FirstName { get; }

        public string LastName { get; }
        public override string ToString()
        {
            return $"Name:{FirstName} {LastName} Id: {Id}";
        }
    }
}
