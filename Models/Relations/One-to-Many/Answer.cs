using MCExercise.Models.Relations.Many_to_Many;
using System.ComponentModel.DataAnnotations.Schema;

namespace MCExercise.Models.Relations.One_to_Many
{
    public class Answer
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid AnswerId { get; set; }
        public string Content { get; set; }
        public bool IsCorrect { get; set; }
        
        public Guid ExerciseId { get; set; }
        public Exercise Exercise { get; set; }
        public ICollection<Attempt> Attempts { get; set; } 
    }
}
