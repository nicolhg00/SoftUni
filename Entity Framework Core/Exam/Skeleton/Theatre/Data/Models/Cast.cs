using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Theatre.Data.Models
{
    public class Cast
    {
        [Key]
        public int Id { get; set; }

        [StringLength(30, MinimumLength = 4)]
        [Required]
        public string FullName { get; set; }

        [Required]
        public bool IsMainCharacter  { get; set; }

        [Required]
        public string PhoneNumber { get; set; }


        [ForeignKey(nameof(Play))]
        public int PlayId { get; set; }
        public Play Play { get; set; }
    }
}
