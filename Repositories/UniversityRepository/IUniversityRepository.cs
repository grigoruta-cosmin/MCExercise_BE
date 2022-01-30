using MCExercise.Models.Relations.One_to_Many;
using MCExercise.Repositories.GenericRepository;

namespace MCExercise.Repositories.UniversityRepository
{
    public interface IUniversityRepository : IGenericRepository<University>
    {
        Task<University> GetByEmail(string email);
    }
}
