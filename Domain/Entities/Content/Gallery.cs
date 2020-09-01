using System.Collections.Generic;
using System.Linq;
using Misty.Domain.Enums;

namespace Misty.Domain.Entities.Content
{
    public class Gallery : Content
    {
        public static int MinimumItemCount = 5;
        private readonly ICollection<GalleryItem> _galleryItems;

        public Gallery(string title, string description,
            Category category = null) : base(title, description, category)
        {
            _galleryItems = new HashSet<GalleryItem>();
            State = ContentState.Hidden;
        }

        private Gallery()
        {
        }

        public IEnumerable<GalleryItem> Items => _galleryItems.ToList();

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