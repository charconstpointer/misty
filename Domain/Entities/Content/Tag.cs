using System;

namespace Misty.Domain.Entities.Content
{
    public class Tag
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public DateTime CreatedAt { get; private set; }

        public Tag(string name)
        {
            Name = name;
            CreatedAt = DateTime.UtcNow;
        }

        private Tag()
        {
        }
    }
}