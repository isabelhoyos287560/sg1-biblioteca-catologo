using Biblioteca.Application.Dtos;
using Library.Application.Common;
using Library.Application.Dtos;

namespace Library.Application.UseCases.Books.Queries
{
    public sealed class GetAllBooksQuery : IRequest<List<BookListDto>>
    {
    }
}