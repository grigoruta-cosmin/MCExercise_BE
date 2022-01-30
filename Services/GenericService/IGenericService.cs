namespace MCExercise.Services.GenericService
{
    public interface IGenericService<TEntity> where TEntity : class
    {
        Task<bool> Create(TEntity entity);
        Task<TEntity> Get(object id);
        Task<List<TEntity>> GetAll();
        Task<bool> Update(TEntity entity);
    }
}
