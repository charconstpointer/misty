using System;

namespace Misty.Domain.Entities.Content.Gallery
{
    public class Image : GalleryItem
    {
        private Image(string path)
        {
            Path = path;
        }

        public static Image Create(string path)
        {
            if (string.IsNullOrEmpty(path)) throw new ArgumentException("Value cannot be null or empty.", nameof(path));
            var image = new Image(path);
            return image;
        }
    }
}