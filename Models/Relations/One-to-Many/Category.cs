using System.ComponentModel.DataAnnotations.Schema;

namespace MCExercise.Models.Relations.One_to_Many
{
    public class Category
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid CategoryId { get; set; }
        public string CategoryName { get; set; }
        
        public Guid UniversityId { get; set; }
        public University University { get; set; }

        public ICollection<Exercise> Exercises { get; set; }
    }
}
