using MCExercise.Entities.Relations.One_to_Many;
using MCExercise.Entities.Relations.One_to_One;

namespace MCExercise.Entities.Relations.Many_to_Many
{
    public class Attempt
    {
        public int UserId { get; set; }
        public int ExerciseId { get; set; }

        public User User { get; set; }
        public Exercise Exercise { get; set; }
        public DateTime AttemptDateTime { get; set; }
        public int AnswerId { get; set; }
    }
}
