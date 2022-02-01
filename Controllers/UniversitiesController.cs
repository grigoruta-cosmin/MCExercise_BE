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
        
        [HttpPut("update")]
        public async Task<IActionResult> Update(UniversityUpdateDTO universityUpdateDTO)
        {
            var resposne = await _universityService.Update(universityUpdateDTO);
            if (!resposne)
            {
                return BadRequest(new { Message = "Update couldn't be done!" });
            }
            return Ok(resposne);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var response = await _universityService.DeleteById(id);
            if (!response)
            {
                return BadRequest(new { Message = "Delete couldn't be done!" });
            }
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = _universityService.GetAll();
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var response = await _universityService.GetById(id);
            if (response == null)
            {
                return BadRequest(new { Message = "University not found!"});
            }
            return Ok(response);
        }

        [HttpGet("summ/{id}")]
        public async Task<IActionResult> GetSummarizationById(Guid id)
        {
            var response = await _universityService.GetSummarization(id);
            if (response == null)
            {
                return BadRequest(new { Message = "Can't get summarization" });
            }
            return Ok(response);
        }
    }
}
