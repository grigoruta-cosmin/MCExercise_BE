using System.ComponentModel.DataAnnotations.Schema;

namespace MCExercise.Entities.Relations.One_to_Many
{
    public class Category
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        
        public int UniversityId { get; set; }
        public University University { get; set; }

        public ICollection<Exercise> Exercises { get; set; }
    }
}
