using System;

namespace Misty.Domain.ValueObjects
{
    public class Resolution
    {
        public int Height { get; private set; }
        public int Width { get; private set; }

        public Resolution(int height, int width)
        {
            ValidateParameters();
            Height = height;
            Width = width;
            
            void ValidateParameters()
            {
                if (height <= 0) throw new ArgumentOutOfRangeException(nameof(height));
                if (width <= 0) throw new ArgumentOutOfRangeException(nameof(width));
            }
        }
    }
}