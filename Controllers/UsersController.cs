using MCExercise.Data;
using MCExercise.Models;
using MCExercise.Models.DTOs;
using MCExercise.Models.Relations.One_to_One;
using MCExercise.Services.UserService;
using MCExercise.Utilities.Attributes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MCExercise.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDTO registerDTO)
        {
            var response = await _userService.Register(registerDTO);
            if (response == null)
            {
                return BadRequest(new { Message = "Username already used!"});
            }
            return Ok(response);
        }

        // [Authorization(Role.User, Role.Admin)]
        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate(UserRequestDTO userRequest)
        {
            var response = await _userService.Authenticate(userRequest);
            if (response == null)
            {
                return BadRequest(new { Message = "Username or Password is invalid!" });
            }
            return Ok(response);
        }

        [Authorization(Role.Admin)]
        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userService.GetAll();
            return Ok(users);
        }
    }
}
