using System;
using System.Collections.Generic;
using System.Linq;
using Misty.Domain.Entities.Users;
using Misty.Domain.Enums;

namespace Misty.Domain.Entities.Content.Gallery
{
    public class Gallery : Content
    {
        public static int MinimumItemCount = 5;
        private readonly ICollection<GalleryItem> _galleryItems;

        public Gallery(string title, string description, Creator creator, Category category = null) : base(title,
            description, creator, category)
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
            if (item == null) throw new ArgumentNullException(nameof(item));
            if (_galleryItems.Contains(item)) return;
            _galleryItems.Add(item);
            item.AddGallery(this);
        }

        public void RemoveItem(GalleryItem item)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));
            var isPresent = _galleryItems.Contains(item);
            if (isPresent) _galleryItems.Remove(item);
        }
    }
}