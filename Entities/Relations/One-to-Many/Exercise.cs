using MCExercise.Entities.Relations.Many_to_Many;
using MCExercise.Entities.Relations.One_to_One;
using System.ComponentModel.DataAnnotations.Schema;

namespace MCExercise.Entities.Relations.One_to_Many
{
    public class Exercise
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ExerciseId { get; set; }
        public string Type { get; set; }
        public string Statement { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public ICollection<Answer> Answers { get; set; }
        public ICollection<Attempt> Attempts { get; set; }
    }
}
