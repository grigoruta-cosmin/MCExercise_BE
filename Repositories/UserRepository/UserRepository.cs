using MCExercise.Data;
using MCExercise.Models.Relations.One_to_One;
using MCExercise.Repositories.GenericRepository;
using Microsoft.EntityFrameworkCore;

namespace MCExercise.Repositories.UserRepository
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(MCExerciseContext context) : base(context)
        {
        }

        public async Task<User> FindIncludePhoto(Guid Id)
        {
            return await _table.Include(user => user.Photo).Where(user => user.UserId.Equals(Id)).FirstOrDefaultAsync();
        }

        public async Task<User> GetByUsername(string username)
        {
            return await _table.Where(user => user.UserName.Equals(username)).FirstOrDefaultAsync();
        }
    }
}
