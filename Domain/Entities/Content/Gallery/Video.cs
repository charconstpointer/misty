using System;

namespace Misty.Domain.Entities.Content.Gallery
{
    public class Video : GalleryItem
    {
        public int Length { get; private set; }

        private Video()
        {
        }

        private Video(string path, int length)
        {
            Path = path;
            Length = length;
        }

        public static Video Create(string path)
        {
            if (string.IsNullOrEmpty(path)) throw new ArgumentException("Value cannot be null or empty.", nameof(path));
            return new Video(path, 0);
        }
    }
}