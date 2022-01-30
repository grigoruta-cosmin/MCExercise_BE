using System.ComponentModel.DataAnnotations.Schema;

namespace MCExercise.Models.Relations.One_to_One
{
    public class Photo
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid PhotoId { get; set; }
        public string Url { get; set; }
        public User User { get; set; }
        public Guid UserId { get; set; }
    }
}
