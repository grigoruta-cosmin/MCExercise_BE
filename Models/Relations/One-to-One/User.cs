using MCExercise.Models.Relations.Many_to_Many;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MCExercise.Models.Relations.One_to_One
{
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        [JsonIgnore]
        public string PasswordHash { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Country { get; set; }
        public string? Bio { get; set; }
        public string Type { get; set; }
        public Photo Photo { get; set; }
        public Role Role { get; set; }
        public ICollection<Attempt> Attempts { get; set; }
    }
}
