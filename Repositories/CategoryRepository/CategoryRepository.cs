using MCExercise.Data;
using MCExercise.Models.DTOs.Category;
using MCExercise.Models.Relations.One_to_Many;
using MCExercise.Repositories.GenericRepository;
using Microsoft.EntityFrameworkCore;

namespace MCExercise.Repositories.CategoryRepository
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(MCExerciseContext context) : base(context)
        {

        }

        public async Task<List<Category>> GetAllByUniversityId(Guid UnviersityId)
        {
            return await _table.Where(category => category.UniversityId.Equals(UnviersityId)).ToListAsync();
        }
    }
}
