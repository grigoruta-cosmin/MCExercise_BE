using MCExercise.Models.DTOs;
using MCExercise.Services.UniversityService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MCExercise.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UniversitiesController : ControllerBase
    {
        private readonly IUniversityService _universityService;

        public UniversitiesController(IUniversityService universityService)
        {
            _universityService = universityService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UniversityRegisterDTO universityRegisterDTO)
        {
            var response = await _universityService.Register(universityRegisterDTO);
            if (response == null)
            {
                return BadRequest(new { Message = "Email already used!" });
            }
            return Ok(response);
        }
        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate(UniversityRequestDTO universityRequestDTO)
        {
            var response = await _universityService.Authenticate(universityRequestDTO);
            if (response == null)
            {
                return BadRequest(new { Message = "Email or Password is invalid!" });
            }
            return Ok(response);
        }
    }
}
