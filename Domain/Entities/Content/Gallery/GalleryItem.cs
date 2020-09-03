using System;
using Misty.Domain.ValueObjects;

namespace Misty.Domain.Entities.Content.Gallery
{
    public abstract class GalleryItem
    {
        protected GalleryItem()
        {
        }

        protected GalleryItem(string path)
        {
            if (string.IsNullOrEmpty(path)) throw new ArgumentException("Value cannot be null or empty.", nameof(path));
            Path = path;
        }

        public int Id { get; }
        public string Path { get; protected set; }
        public Resolution Resolution { get; protected set; }
        public Gallery Gallery { get; protected set; }

        public void SetGallery(Gallery gallery)
        {
            if (gallery == null) throw new ArgumentNullException(nameof(gallery));
            if (Gallery != null) return;
            Gallery = gallery;
            gallery.AddItem(this);
        }

        public static GalleryItem Create(string path, bool isVideo = false)
        {
            if (string.IsNullOrEmpty(path)) throw new ArgumentException("Value cannot be null or empty.", nameof(path));
            GalleryItem item;
            if (isVideo)
            {
                item = Video.Create(path);
            }
            else
            {
                item = Image.Create(path);
            }

            return item;
        }
    }
}