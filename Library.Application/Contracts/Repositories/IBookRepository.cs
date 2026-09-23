using Library.Domain.Entities;

namespace Library.Application.Contracts.Repositories
{
    public interface IBookRepository : IRepository<Book>
    {
        Task<List<Book>> GetByCategoryAsync(Guid categoryId, CancellationToken cancellationToken);
    }
}