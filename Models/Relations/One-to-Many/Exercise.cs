using MCExercise.Models.Relations.Many_to_Many;
using System.ComponentModel.DataAnnotations.Schema;

namespace MCExercise.Models.Relations.One_to_Many
{
    public class Exercise
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ExerciseId { get; set; }
        public string Type { get; set; }
        public string Statement { get; set; }

        public Guid CategoryId { get; set; }
        public Category Category { get; set; }

        public ICollection<Answer> Answers { get; set; }
        public ICollection<Attempt> Attempts { get; set; }
    }
}
