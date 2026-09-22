namespace Library.Domain.Entities
{
    public sealed class Book
    {
        public Guid Id { get; private set; }
        public string Title { get; private set; } = null!;
        public string Isbn { get; private set; } = null!;
        public int PublicationYear { get; private set; }

        public Guid AuthorId { get; private set; }
        public Author Author { get; set; } = null!;

        public Guid CategoryId { get; private set; }
        public Category Category { get; set; } = null!;

        private Book() { }

        public Book(string title, string isbn, int publicationYear, Guid authorId, Guid categoryId)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentException("The title is required.");

            if (string.IsNullOrWhiteSpace(isbn))
                throw new ArgumentException("The ISBN is required.");

            if (publicationYear < 1450 || publicationYear > DateTime.UtcNow.Year)
                throw new ArgumentException("The publication year is not valid.");

            Id = Guid.NewGuid();
            Title = title;
            Isbn = isbn;
            PublicationYear = publicationYear;
            AuthorId = authorId;
            CategoryId = categoryId;
        }
    }
}
