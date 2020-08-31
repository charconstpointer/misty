using System.Collections.Generic;

namespace Misty.Domain.Entities.Content
{
    public class Gallery : Content
    {
        private readonly ICollection<GalleryItem> _galleryItems;

        public Gallery(string title, string description,
            Category category = null) : base(title, description, category)
        {
            _galleryItems = new HashSet<GalleryItem>();
        }
    }
}