using System;

namespace Misty.Domain.ValueObjects
{
    public class Tag
    {
        private Tag()
        {
        }

        private Tag(string name)
        {
            Name = name;
        }

        public string Name { get; }
        public DateTime CreatedAt { get; private set; }

        public static Tag Create(string name)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentException("Value cannot be null or empty.", nameof(name));
            var tag = new Tag(name);
            return tag;
        }
    }
}