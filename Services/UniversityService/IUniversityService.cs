using MCExercise.Models.DTOs;
using MCExercise.Models.DTOs;
using MCExercise.Models.Relations.One_to_Many;
using MCExercise.Services.GenericService;

namespace MCExercise.Services.UniversityService
{
    public interface IUniversityService : IGenericService<University>
    {
        Task<UniversityResponseDTO> Register(UniversityRegisterDTO universityRegisterDTO);
        Task<UniversityResponseDTO> Authenticate(UniversityRequestDTO universityRequestDTO);
        Task<University> GetById(Guid Id);
        Task<bool> Update(UniversityUpdateDTO universityUpdateDTO);
        Task<bool> DeleteById(Guid Id);
        Task<UniversityCategorySummarizationDTO> GetSummarization(Guid Id);
    }
}
