using MCExercise.Entities.Relations.Many_to_Many;
using MCExercise.Entities.Relations.One_to_Many;
using System.ComponentModel.DataAnnotations.Schema;

namespace MCExercise.Entities.Relations.One_to_One
{
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        public string UserName { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Country { get; set; }
        public string? Bio { get; set; }
        public string Type { get; set; }
        public Photo Photo { get; set; }

        public ICollection<Attempt> Attempts { get; set; }
    }
}
