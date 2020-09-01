using System.Collections.Generic;
using System.Linq;

namespace Misty.Domain.Entities.Content
{
    public class Gallery : Content
    {
        private readonly ICollection<GalleryItem> _galleryItems;
        public IEnumerable<GalleryItem> Items => _galleryItems.ToList();

        public Gallery(string title, string description,
            Category category = null) : base(title, description, category)
        {
            _galleryItems = new HashSet<GalleryItem>();
        }
        private Gallery(){}
        public void AddItem(GalleryItem item)
        {
            _galleryItems.Add(item);
        }

        public void RemoveItem(GalleryItem item)
        {
            var isPresent = _galleryItems.Contains(item);
            if (isPresent) _galleryItems.Remove(item);
        }
    }
}