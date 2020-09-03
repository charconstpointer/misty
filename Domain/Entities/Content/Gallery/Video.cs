namespace Misty.Domain.Entities.Content.Gallery
{
    public class Video : GalleryItem
    {
        public Video(string path, int length)
        {
            Path = path;
            Length = length;
        }

        public int Length { get; }
    }
}