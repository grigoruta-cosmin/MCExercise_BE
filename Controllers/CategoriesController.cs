using MCExercise.Models.DTOs.Category;
using MCExercise.Models.Relations.One_to_Many;
using MCExercise.Services.CategoryService;
using MCExercise.Services.UniversityService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MCExercise.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IUniversityService _universityService;
        public CategoriesController(ICategoryService categoryService, IUniversityService universityService)
        {
            _categoryService = categoryService;
            _universityService = universityService;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var response = await _categoryService.Delete(id);
            if (!response)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAllByUniversityId(Guid Id)
        {
            var response = await _categoryService.GetByUniversityId(Id);
            if (response.Count == 0)
            {
                return BadRequest(new { Message = "University doesn't have any service" });
            }
            return Ok(response);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(CategoryDTO categoryDTO)
        {
            var university = await _universityService.GetById(categoryDTO.UniversityId);
            if (university == null)
            {
                return BadRequest(false);
            }
            var category = new Category
            {
                CategoryName = categoryDTO.CategoryName,
                UniversityId = categoryDTO.UniversityId,
                University = university
            };
            var result = await _categoryService.Create(category);
            return Ok(result);
        }
    }
}
