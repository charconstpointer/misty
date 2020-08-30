using System;

namespace Misty.Domain.Entities
{
    public class Category
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        

        public Category(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}