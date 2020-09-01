namespace Misty.Domain.Entities.Content
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
        public string Name { get; private set; }
        public string Description { get; private set; }
    }
}