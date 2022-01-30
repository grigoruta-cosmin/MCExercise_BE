using MCExercise.Models.Relations.One_to_Many;
using MCExercise.Models.Relations.One_to_One;

namespace MCExercise.Models.Relations.Many_to_Many
{
    public class Attempt
    {
        public Guid UserId { get; set; }
        public Guid ExerciseId { get; set; }

        public User User { get; set; }
        public Exercise Exercise { get; set; }
        public DateTime AttemptDateTime { get; set; }
        public bool IsCorrect { get; set; }
        public Guid? AnswerId { get; set; }
        public Answer? Answer { get; set; }
    }
}
