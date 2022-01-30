using MCExercise.Data;
using MCExercise.Models.Relations.One_to_Many;
using MCExercise.Repositories.GenericRepository;
using Microsoft.EntityFrameworkCore;

namespace MCExercise.Repositories.UniversityRepository
{
    public class UniversityRepository : GenericRepository<University>, IUniversityRepository
    {
        public UniversityRepository(MCExerciseContext context) : base(context)
        {
        }

        public async Task<University> GetByEmail(string email)
        {
            return await _table.Where(university => university.Email.Equals(email)).FirstOrDefaultAsync();
        }
    }
}
