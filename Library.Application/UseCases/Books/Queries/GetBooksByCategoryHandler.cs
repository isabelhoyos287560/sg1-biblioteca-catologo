using Biblioteca.Application.Dtos;
using Library.Application.Common;
using Library.Application.Contracts.Repositories;
using Library.Application.Dtos;

namespace Library.Application.UseCases.Books.Queries
{
    public sealed class GetBooksByCategoryHandler : IRequestHandler<GetBooksByCategoryQuery, List<BookListDto>>
    {
        private readonly IBookRepository _bookRepository;

        public GetBooksByCategoryHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<List<BookListDto>> HandleAsync(GetBooksByCategoryQuery request, CancellationToken cancellationToken)
        {
            var books = await _bookRepository.GetByCategoryAsync(request.CategoryId, cancellationToken);

            return books.Select(b => new BookListDto
            {
                Id = b.Id,
                Title = b.Title,
                Isbn = b.Isbn,
                PublicationYear = b.PublicationYear,
                AuthorName = b.Author.Name,
                CategoryName = b.Category.Name
            }).ToList();
        }
    }
}