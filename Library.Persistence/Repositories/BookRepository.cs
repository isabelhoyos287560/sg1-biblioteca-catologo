using Library.Application.Contracts.Repositories;
using Library.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Library.Persistence.Repositories
{
    public sealed class BookRepository : Repository<Book>, IBookRepository
    {
        public BookRepository(LibraryDbContext context) : base(context)
        {
        }

        public override async Task<Book?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _context.Set<Book>()
                .Include(b => b.Author)
                .Include(b => b.Category)
                .FirstOrDefaultAsync(b => b.Id == id, cancellationToken);
        }

        public override async Task<List<Book>> GetListAsync(CancellationToken cancellationToken)
        {
            return await _context.Set<Book>()
                .Include(b => b.Author)
                .Include(b => b.Category)
                .ToListAsync(cancellationToken);
        }

        public async Task<List<Book>> GetByCategoryAsync(Guid categoryId, CancellationToken cancellationToken)
        {
            return await _context.Set<Book>()
                .Include(b => b.Author)
                .Include(b => b.Category)
                .Where(b => b.CategoryId == categoryId)
                .ToListAsync(cancellationToken);
        }
    }
}