using Biblioteca.Application.Dtos;
using Library.Application.Common;
using Library.Application.Dtos;

namespace Library.Application.UseCases.Books.Queries
{
    public sealed class GetBooksByCategoryQuery : IRequest<List<BookListDto>>
    {
        public Guid CategoryId { get; set; }

        public GetBooksByCategoryQuery(Guid categoryId)
        {
            CategoryId = categoryId;
        }
    }
}