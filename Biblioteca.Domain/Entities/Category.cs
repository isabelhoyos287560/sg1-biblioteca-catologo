namespace Library.Domain.Entities
{
    public sealed class Category
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; } = null!;

        private Category() { }

        public Category(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("El nombre de la categoría es requerida");

            Id = Guid.NewGuid();
            Name = name;

        }
    }
}
