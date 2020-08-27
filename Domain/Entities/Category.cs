using System;

namespace Misty.Domain.Entities
{
    public class Category
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        

        public Category(int id, string name, string description)
        {
            var random = new Random();
            Id = random.Next(int.MaxValue);
            Name = name;
            Description = description;
        }
    }
}