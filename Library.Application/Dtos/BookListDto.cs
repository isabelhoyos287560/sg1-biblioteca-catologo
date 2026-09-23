namespace Biblioteca.Application.Dtos
{
    public sealed class BookListDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = null!;
        public string Isbn { get; set; } = null!;
        public int PublicationYear { get; set; }
        public string AuthorName { get; set; } = null!;
        public string CategoryName { get; set; } = null!;
    }
}
