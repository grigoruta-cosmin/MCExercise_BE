using System.ComponentModel.DataAnnotations;

namespace MCExercise.Models.DTOs
{
    public class UniversityRequestDTO
    {
        [Required]
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
