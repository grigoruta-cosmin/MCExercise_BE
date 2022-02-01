using MCExercise.Models.DTOs.Category;
using MCExercise.Models.Relations.One_to_Many;
using MCExercise.Repositories.CategoryRepository;
using MCExercise.Repositories.GenericRepository;
using MCExercise.Services.GenericService;

namespace MCExercise.Services.CategoryService
{
    public class CategoryService : GenericService<Category>, ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryService(ICategoryRepository categoryRepository) : base(categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<List<CategoryDTO>> GetByUniversityId(Guid universityId)
        {
            var response = await _categoryRepository.GetAllByUniversityId(universityId);
            List<CategoryDTO> mapped = new List<CategoryDTO>();
            foreach (var category in response)
            {
                mapped.Add(new CategoryDTO { Id = category.CategoryId, CategoryName = category.CategoryName, UniversityId = universityId });
            }
            return mapped;
        }

        public async Task<bool> Delete(Guid id)
        {
            var category = await _categoryRepository.FindByIdAsync(id);
            if (category == null)
            {
                return false;
            }
            _categoryRepository.Delete(category);
            return await _categoryRepository.SaveAsync();
        }
    }
}
