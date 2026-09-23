namespace Library.Domain.Entities
{
    public sealed class Author    
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; } = null!;

        private Author() { }

        public Author(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("El nombre de la author es requerida");

            Id = Guid.NewGuid();
            Name = name;
            
        }
    }
}
