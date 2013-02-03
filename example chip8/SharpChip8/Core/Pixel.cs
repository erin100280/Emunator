using System;

namespace SharpChip8.Core
{
    public enum PixelColor
    {
        White = 0, Black = 1
    }

    public class Pixel
    {
        public static int PixelDim = 8;
		public static int PixelWidth = 8;
		public static int PixelHeight = 8;

        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public PixelColor Color { get; set; }
		public int Value { get; set; }

        public Pixel()
        {
            this.X = 0;
            this.Y = 0;
            this.Width = PixelWidth;
            this.Height = PixelHeight;
            this.Color = PixelColor.Black;
			this.Value = 1;
        }

        public Pixel(int x, int y, int width, int height, PixelColor color)
        {
            this.X = x;
            this.Y = y;
            this.Width = width;
            this.Height = height;
            this.Color = color;
			if (color == PixelColor.Black)
				this.Value = 1;
			else
				this.Value = 0;
        }
    }
}
