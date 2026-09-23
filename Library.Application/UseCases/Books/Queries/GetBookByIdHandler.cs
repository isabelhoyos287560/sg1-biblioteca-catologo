using Library.Application.Common;
using Library.Application.Contracts.Repositories;
using Library.Application.Dtos;

namespace Library.Application.UseCases.Books.Queries
{
    public sealed class GetBookByIdHandler : IRequestHandler<GetBookByIdQuery, BookDetailDto?>
    {
        private readonly IBookRepository _bookRepository;

        public GetBookByIdHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<BookDetailDto?> HandleAsync(GetBookByIdQuery request, CancellationToken cancellationToken)
        {
            var book = await _bookRepository.GetByIdAsync(request.Id, cancellationToken);

            if (book is null)
                return null;

            return new BookDetailDto
            {
                Id = book.Id,
                Title = book.Title,
                Isbn = book.Isbn,
                PublicationYear = book.PublicationYear,
                AuthorId = book.AuthorId,
                AuthorName = book.Author.Name,
                CategoryId = book.CategoryId,
                CategoryName = book.Category.Name
            };
        }
    }
}