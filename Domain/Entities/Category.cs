namespace Misty.Domain.Entities
{
    public class Category
    {
        public Category(string name, string description)
        {
            Name = name;
            Description = description;
        }

        private Category()
        {
        }

        public int Id { get; private set; }
        public string Name { get; }
        public string Description { get; }
    }
}