using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MCExercise.Models.Relations.One_to_Many
{
    public class University
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid UniversityId { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Type { get; set; }
        public string Email { get; set; }
        [JsonIgnore]
        public string PasswordHash { get; set; }
        public string? About { get; set; }

        public ICollection<Category> Categories { get; set; }
    }
}
