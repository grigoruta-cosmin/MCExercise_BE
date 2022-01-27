using MCExercise.Entities.Relations.One_to_One;

namespace MCExercise.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(User user);
    }
}
