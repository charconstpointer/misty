using System;

namespace Misty.Domain.Entities.Content
{
    public class Category
    {
        private Category()
        {
        }

        public Category(string name, string description)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Description = description ?? throw new ArgumentNullException(nameof(description));
        }


        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
    }
}