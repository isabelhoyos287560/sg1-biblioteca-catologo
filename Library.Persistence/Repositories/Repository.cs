using Library.Application.Contracts.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Library.Persistence.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly LibraryDbContext _context;

        public Repository(LibraryDbContext context)
        {
            _context = context;
        }

        public virtual async Task<TEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _context.Set<TEntity>().FindAsync(new object[] { id }, cancellationToken);
        }

        public virtual async Task<List<TEntity>> GetListAsync(CancellationToken cancellationToken)
        {
            return await _context.Set<TEntity>().ToListAsync(cancellationToken);
        }
    }
}