using System;

namespace MyPhotoshop
{
	public class Photo
	{
		public readonly int width;
		public readonly int height;
		private readonly Pixel[,] data;

        public ref Pixel this[int x, int y]
        {
            get { return ref data[x, y]; }
        }

        public Photo(int width, int height)
        {
            this.width = width;
            this.height = height;

            data = new Pixel[width, height];
        }
	}
}

