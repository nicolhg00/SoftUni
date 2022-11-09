﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using VaporStore.Data.Models.Enums;

namespace VaporStore.Data.Models
{
    public class Purchase
    {
        [Key]
        public int Id { get; set; }

        public PurchaseType Type { get; set; }

        public string ProductKey  { get; set; }

        public DateTime Date { get; set; }


        [ForeignKey(nameof(Card))]
        public int CardId { get; set; }

        [Required]
        public Card Card { get; set; }


        [ForeignKey(nameof(Game))]
        public int GameId { get; set; }

        [Required]
        public Game Game { get; set; }
    }
}
