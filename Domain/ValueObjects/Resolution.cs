using System;

namespace Misty.Domain.ValueObjects
{
    public class Resolution
    {
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

        public int Height { get; }
        public int Width { get; }
    }
}