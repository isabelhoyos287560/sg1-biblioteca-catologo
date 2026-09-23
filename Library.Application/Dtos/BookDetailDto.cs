namespace Library.Application.Dtos
{
    public sealed class BookDetailDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = null!;
        public string Isbn { get; set; } = null!;
        public int PublicationYear { get; set; }
        public Guid AuthorId { get; set; }
        public string AuthorName { get; set; } = null!;
        public Guid CategoryId { get; set; }
        public string CategoryName { get; set; } = null!;
    }
}