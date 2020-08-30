using System;

namespace Misty.Domain.Entities
{
    public class Ad
    {
        private Ad()
        {
        }

        public int Id { get; }
        public string Path { get; private set; }
        public DateTime CreatedAt { get; }

        public Ad(string path)
        {
            //TODO validate if valid url
            Path = path;
            CreatedAt = DateTime.UtcNow;
        }
    }
}