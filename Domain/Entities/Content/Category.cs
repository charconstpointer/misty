using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text.Json.Serialization;

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
        private readonly ICollection<Content> _contents = new List<Content>();
        [JsonIgnore] public ICollection<Content> Contents => _contents.ToImmutableList();

        public void AddContent(Content content)
        {
            if (content == null) throw new ArgumentNullException(nameof(content));
            if (_contents.Contains(content))
            {
                return;
            }

            _contents.Add(content);
        }
    }
}