using System;

namespace Misty.Domain.Entities.Content.Gallery
{
    public class Video : GalleryItem
    {
        public int Length { get; private set; }

        public Video(string path, int length)
        {
            Path = path;
            Length = length;
        }
    }
}