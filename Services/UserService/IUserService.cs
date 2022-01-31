using MCExercise.Models.DTOs;
using MCExercise.Models.Relations.One_to_One;
using MCExercise.Services.GenericService;

namespace MCExercise.Services.UserService
{
    public interface IUserService : IGenericService<User>
    {
        Task<UserResponseDTO> Register(RegisterDTO registerDTO);
        Task<UserResponseDTO> Authenticate(UserRequestDTO userRequest);
        Task<User> GetById(Guid id);
        Task<bool> Update(UserUpdateDTO userUpdateDTO);
        Task<bool> Delete(Guid id);
    }
}
