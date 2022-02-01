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

        public async Task<UserUpdateDTO> GetByIdWithPhoto(Guid id)
        {
            var user = await _userRepository.FindIncludePhoto(id);
            return new UserUpdateDTO
            {
                UserId = user.UserId,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Username = user.UserName,
                Email = user.Email,
                Country = user.Country,
                Type = user.Type,
                PhotoUrl = user.Photo?.Url
            };
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

        public async Task<bool> Update(UserUpdateDTO userUpdateDTO)
        {
            var user = await _userRepository.FindByIdAsync(userUpdateDTO.UserId);
            if (user == null)
                return false;
            if (userUpdateDTO.NewPassword != null)
            {
                user.PasswordHash = BCryptNet.HashPassword(userUpdateDTO.NewPassword);
            }
            user.UserId = userUpdateDTO.UserId;
            user.UserName = userUpdateDTO.Username;
            user.FirstName = userUpdateDTO.FirstName;
            user.LastName = userUpdateDTO.LastName;
            user.Email = userUpdateDTO.Email;
            user.Country = userUpdateDTO.Country;
            user.Bio = userUpdateDTO.Bio;
            user.Type = userUpdateDTO.Type;
            _userRepository.Update(user);
            var result =  _userRepository.Save();
            return result;
        }

        public async Task<bool> Delete(Guid id)
        {
            var user = await _userRepository.FindByIdAsync(id);
            _userRepository.Delete(user);
            var result = await _userRepository.SaveAsync();
            return result;
        }
    }
}
