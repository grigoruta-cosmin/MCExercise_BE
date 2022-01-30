using MCExercise.Models.Relations.One_to_One;
using MCExercise.Repositories.GenericRepository;

namespace MCExercise.Repositories.UserRepository
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User> GetByUsername(string username);
    }
}
