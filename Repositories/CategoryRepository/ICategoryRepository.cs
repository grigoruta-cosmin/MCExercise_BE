using MCExercise.Models.DTOs.Category;
using MCExercise.Models.Relations.One_to_Many;
using MCExercise.Repositories.GenericRepository;

namespace MCExercise.Repositories.CategoryRepository
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        Task<List<Category>> GetAllByUniversityId(Guid UnviersityId);
    }
}
