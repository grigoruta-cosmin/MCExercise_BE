using MCExercise.Repositories.GenericRepository;

namespace MCExercise.Services.GenericService
{
    public class GenericService<TEntity> : IGenericService<TEntity> where TEntity : class
    {
        public IGenericRepository<TEntity> _genericRepository;

        public GenericService(IGenericRepository<TEntity> genericRepository)
        {
            _genericRepository = genericRepository;
        }
        public async Task<bool> Create(TEntity entity)
        {
            await _genericRepository.CreateAsync(entity);
            return await _genericRepository.SaveAsync();
        }

        public async Task<TEntity> Get(object id)
        {
            return await _genericRepository.FindByIdAsync(id);
        }

        public async Task<List<TEntity>> GetAll()
        {
            return await _genericRepository.GetAll();
        }

        public async Task<bool> Update(TEntity entity)
        {
            _genericRepository.Update(entity);
            return await _genericRepository.SaveAsync();
        }
    }
}
