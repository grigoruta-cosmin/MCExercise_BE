using MCExercise.Models.Relations.One_to_Many;

namespace MCExercise.Models.DTOs
{
    public class UniversityResponseDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }

        public UniversityResponseDTO(University university, string token)
        {
            Id = university.UniversityId;
            Name = university.Name;
            Email = university.Email;
            Token = token;
        }
    }
}
