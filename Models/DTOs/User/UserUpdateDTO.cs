using MCExercise.Models.Relations.One_to_One;

namespace MCExercise.Models.DTOs
{
    public class UserUpdateDTO
    {
        public Guid UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string? NewPassword { get; set; }
        public string Email { get; set; }
        public string Country { get; set; }
        public string? Bio { get; set; }
        public string Type { get; set; }
        public string PhotoUrl { get; set; }
    }
}
