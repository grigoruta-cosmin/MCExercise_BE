using System.ComponentModel.DataAnnotations.Schema;

namespace MCExercise.Entities.Relations.One_to_Many
{
    public class Answer
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AnswerId { get; set; }
        public string Content { get; set; }
        public bool IsCorrect { get; set; }
        
        public int ExerciseId { get; set; }
        public Exercise Exercise { get; set; }
    }
}
