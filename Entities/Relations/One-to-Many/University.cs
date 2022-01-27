using System.ComponentModel.DataAnnotations.Schema;

namespace MCExercise.Entities.Relations.One_to_Many
{
    public class University
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UniversityId { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Type { get; set; }
        public string Email { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string About { get; set; }

        public ICollection<Category> Categories { get; set; }
    }
}
