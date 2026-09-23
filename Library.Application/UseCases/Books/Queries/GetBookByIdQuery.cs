using Library.Application.Common;
using Library.Application.Dtos;

namespace Library.Application.UseCases.Books.Queries
{
    public sealed class GetBookByIdQuery : IRequest<BookDetailDto?>
    {
        public Guid Id { get; set; }

        public GetBookByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}