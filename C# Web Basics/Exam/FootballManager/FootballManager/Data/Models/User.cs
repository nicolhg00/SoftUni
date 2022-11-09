﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballManager.Data.Models
{
    public class User
    {
        [Key]
        [StringLength(36)]
        public string Id { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 5)]
        public string Username { get; set; }

        [Required]
        [StringLength(60, MinimumLength = 10)]
        public string Email { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 5)]
        public string Password { get; set; }
        public ICollection<UserPlayer> UserPlayers { get; set; }

        public User()
        {
            Id = Guid.NewGuid().ToString();
            UserPlayers = new List<UserPlayer>();
        }

    }
}