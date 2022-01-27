﻿using System.ComponentModel.DataAnnotations;

namespace MCExercise.DTOs
{
    public class RegisterDTO
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Firstname { get; set; }
        [Required]
        public string Lastname { get; set; }
        [Required]
        public string Email { get; set; }
        public string Country { get; set; }
        [Required]
        public string Type { get; set; }
    }
}
