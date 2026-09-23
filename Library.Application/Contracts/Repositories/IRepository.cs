namespace Library.Application.Contracts.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<TEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        Task<List<TEntity>> GetListAsync(CancellationToken cancellationToken);
    }
}