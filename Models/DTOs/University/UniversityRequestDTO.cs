using System.ComponentModel.DataAnnotations;

namespace MCExercise.Models.DTOs
{
    public class UniversityRequestDTO
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
