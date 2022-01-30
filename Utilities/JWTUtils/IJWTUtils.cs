using MCExercise.Models.Relations.One_to_Many;
using MCExercise.Models.Relations.One_to_One;

namespace MCExercise.Utilities.JWTUtils
{
    public interface IJWTUtils
    {
        public string GenerateJWTToken(University university);
        public string GenerateJWTToken(User user);
        public Guid ValidateJWTToken(string token);
    }
}
