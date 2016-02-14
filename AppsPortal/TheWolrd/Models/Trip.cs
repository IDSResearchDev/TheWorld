using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TheWolrd.Models
{
    public class Trip
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255,MinimumLength = 5)]
        public string Name { get; set; }
        public DateTime Created { get; set; }
        public string UserName { get; set; }

        public ICollection<Stop> Stops { get; set; }
    }
}
