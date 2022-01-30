using MCExercise.Models.DTOs;
using MCExercise.Models.Relations.One_to_Many;
using MCExercise.Repositories.UniversityRepository;
using MCExercise.Services.GenericService;
using MCExercise.Utilities;
using MCExercise.Utilities.JWTUtils;
using Microsoft.Extensions.Options;
using BCryptNet = BCrypt.Net.BCrypt;

namespace MCExercise.Services.UniversityService
{
    public class UniversityService : GenericService<University>, IUniversityService
    {
        public IUniversityRepository _universityRepository;
        public IJWTUtils _iJWTUtils;
        private readonly AppSettings _appSettings;

        public UniversityService(IUniversityRepository universityRepository, IJWTUtils iJWTUtils, IOptions<AppSettings> appSettings) : base(universityRepository)
        {
            _universityRepository = universityRepository;
            _iJWTUtils = iJWTUtils;
            _appSettings = appSettings.Value;
        }

        public async Task<UniversityResponseDTO> Register(UniversityRegisterDTO universityRegisterDTO)
        {
            var test = await _universityRepository.GetByEmail(universityRegisterDTO.Email);
            if (test != null)
            {
                return null;
            }
            var university = new University
            {
                Name = universityRegisterDTO.Name,
                PasswordHash = BCryptNet.HashPassword(universityRegisterDTO.Password),
                Country = universityRegisterDTO.Country,
                Type = universityRegisterDTO.Type,
                Email = universityRegisterDTO.Email,
                City = universityRegisterDTO.City
            };
            await _universityRepository.CreateAsync(university);
            var jwtToken = _iJWTUtils.GenerateJWTToken(university);
            await _universityRepository.SaveAsync();
            return new UniversityResponseDTO(university, jwtToken);
        }

        public async Task<UniversityResponseDTO> Authenticate(UniversityRequestDTO universityRequestDTO)
        {
            var university = await _universityRepository.GetByEmail(universityRequestDTO.Email);
            if (university == null | !BCryptNet.Verify(universityRequestDTO.Password, university.PasswordHash))
                return null;
            var jwtToken = _iJWTUtils.GenerateJWTToken(university);
            return new UniversityResponseDTO(university, jwtToken);
        }

        public async Task<University> GetById(Guid id)
        {
            return await _universityRepository.FindByIdAsync(id);
        }
    }
}
