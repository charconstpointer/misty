using System;
using Misty.Domain.ValueObjects;

namespace Misty.Domain.Entities.Content.Gallery
{
    public abstract class GalleryItem
    {
        public int Id { get; }
        public string Path { get; protected set; }
        public Resolution Resolution { get; protected set; }
        public Gallery Gallery { get; protected set; }

        protected GalleryItem()
        {
        }

        protected GalleryItem(string path)
        {
            if (string.IsNullOrEmpty(path)) throw new ArgumentException("Value cannot be null or empty.", nameof(path));
            Path = path;
        }

        public void AddGallery(Gallery gallery)
        {
            if (gallery == null) throw new ArgumentNullException(nameof(gallery));
            if (Gallery != null) return;
            Gallery = gallery;
            gallery.AddItem(this);
        }
    }
}