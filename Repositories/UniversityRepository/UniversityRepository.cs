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

        public async Task<object> GetCategoriesCountsById(Guid Id)
        {
            return await _table.Where(university => university.UniversityId.Equals(Id))
                               .Join(_context.Categories, university => university.UniversityId, category => category.UniversityId, (university, category) => new
                               {
                                   university.UniversityId
                                    ,
                                   university.Email,
                                   university.Name,
                                   category.CategoryId
                               }).GroupBy(univeristy => new { univeristy.UniversityId, univeristy.Name, univeristy.Email }, (param1, param2) => new
                               {
                                   param1.UniversityId,
                                   param1.Name,
                                   param1.Email,
                                   CategoryCount = param2.Count()

                               }).FirstOrDefaultAsync();

        }
    }
}
