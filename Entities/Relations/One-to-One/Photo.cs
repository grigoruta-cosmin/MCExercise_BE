using System.ComponentModel.DataAnnotations.Schema;

namespace MCExercise.Entities.Relations.One_to_One
{
    public class Photo
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PhotoId { get; set; }
        public string Url { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
    }
}
