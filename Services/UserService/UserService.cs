using MCExercise.Models;
using MCExercise.Models.DTOs;
using MCExercise.Models.Relations.One_to_One;
using MCExercise.Repositories.UserRepository;
using MCExercise.Services.GenericService;
using MCExercise.Utilities;
using MCExercise.Utilities.JWTUtils;
using Microsoft.Extensions.Options;
using BCryptNet = BCrypt.Net.BCrypt;

namespace MCExercise.Services.UserService
{
    public class UserService : GenericService<User>, IUserService
    {
        public IUserRepository _userRepository;
        public IJWTUtils _iJWTUtils;
        private readonly AppSettings _appSettings;
        public UserService(IUserRepository userRepository, IJWTUtils iJWTUtils, IOptions<AppSettings> appSettings) : base(userRepository)
        {
            _userRepository = userRepository;
            _iJWTUtils = iJWTUtils;
            _appSettings = appSettings.Value;
        }

        public async Task<UserResponseDTO> Register(RegisterDTO registerDTO)
        {
            var test = await _userRepository.GetByUsername(registerDTO.Username);
            if (test != null)
            {
                return null;
            }
            var user = new User
            {
                UserName = registerDTO.Username,
                PasswordHash = BCryptNet.HashPassword(registerDTO.Password),
                FirstName = registerDTO.Firstname,
                LastName = registerDTO.Lastname,
                Email = registerDTO.Email,
                Country = registerDTO.Country,
                Type = registerDTO.Type,
                Role = Role.User
            };
            await _userRepository.CreateAsync(user);
            var jwtToken = _iJWTUtils.GenerateJWTToken(user);
            await _userRepository.SaveAsync();
            return new UserResponseDTO(user, jwtToken);
        } 

        public async Task<UserResponseDTO> Authenticate(UserRequestDTO userRequest)
        {
            var user = await _userRepository.GetByUsername(userRequest.Username);
            if (user == null || !BCryptNet.Verify(userRequest.Password, user.PasswordHash))
                return null;
            var jwtToken = _iJWTUtils.GenerateJWTToken(user);
            return new UserResponseDTO(user, jwtToken);
        } 

        public async Task<User> GetById(Guid id)
        {
            return await _userRepository.FindByIdAsync(id);
        }
    }
}
