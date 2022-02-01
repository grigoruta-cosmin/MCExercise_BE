using MCExercise.Models.DTOs.Category;
using MCExercise.Models.Relations.One_to_Many;
using MCExercise.Services.GenericService;

namespace MCExercise.Services.CategoryService
{
    public interface ICategoryService : IGenericService<Category>
    {
        Task<List<CategoryDTO>> GetByUniversityId(Guid universityId);
        Task<bool> Delete(Guid id);
    }
}
