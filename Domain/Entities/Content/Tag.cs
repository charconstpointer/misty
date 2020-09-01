using System;

namespace Misty.Domain.Entities.Content
{
    public class Tag
    {
        public Tag(string name)
        {
            Name = name;
            CreatedAt = DateTime.UtcNow;
        }

        private Tag()
        {
        }

        public int Id { get; private set; }
        public string Name { get; }
        public DateTime CreatedAt { get; }
    }
}