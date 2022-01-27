using MCExercise.Data;
using MCExercise.DTOs;
using MCExercise.Entities.Relations.One_to_One;
using MCExercise.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace MCExercise.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly MCExerciseContext _context;
        private readonly ITokenService _tokenService;

        public AccountController(MCExerciseContext context, ITokenService tokenService)
        {
            _context = context;
            _tokenService = tokenService;
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserDTO>> Register(RegisterDTO registerDTO)
        {
            if (await UserExists(registerDTO.Username)) return BadRequest("Username is taken!");

            using var hmac = new HMACSHA512();

            var user = new User
            {
                UserName = registerDTO.Username,
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDTO.Password)),
                PasswordSalt = hmac.Key,
                FirstName = registerDTO.Firstname,
                LastName = registerDTO.Lastname,
                Email = registerDTO.Email,
                Country = registerDTO.Country,
                Type = registerDTO.Type,
            };

            _context.Add(user);
            await _context.SaveChangesAsync();

            return new UserDTO
            {
                UserName = user.UserName,
                Token = _tokenService.CreateToken(user)
            };
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDTO>> Login(LoginDTO loginDTO)
        {
            var user = await _context.Users.SingleOrDefaultAsync(u => u.UserName == loginDTO.Username);
            if (user == null) return Unauthorized("Username does not exists!");
            using var hmac = new HMACSHA512(user.PasswordSalt);
            var hashedPassword = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDTO.Password));
            for (int i = 0; i < user.PasswordHash.Length; i++)
                if (hashedPassword[i] != user.PasswordHash[i])
                    return Unauthorized("Wrong password!");
            return new UserDTO
            {
                UserName = loginDTO.Username,
                Token = _tokenService.CreateToken(user)
            };
        }

        private async Task<bool> UserExists(string username)
        {
            return await _context.Users.AnyAsync(x => x.UserName == username.ToLower());
        }
    }
}
