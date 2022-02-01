
namespace MCExercise.Models.DTOs
{
    public class UniversityUpdateDTO
    {
        public Guid UniversityId { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Type { get; set; }
        public string Email { get; set; }
        public string? NewPassword { get; set; }
        public string? About { get; set; }
    }
}
