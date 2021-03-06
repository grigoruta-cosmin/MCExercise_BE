using System.ComponentModel.DataAnnotations;

namespace MCExercise.Models.DTOs
{
    public class UserRequestDTO
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
