using System;
using System.ComponentModel.DataAnnotations;

namespace TheWolrd.ViewModels
{


    public class ContactViewModel
    {
        [Required]
        [StringLength(255,MinimumLength =5)]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(102476, MinimumLength = 5)]
        public string Message { get; set; }
    }
}