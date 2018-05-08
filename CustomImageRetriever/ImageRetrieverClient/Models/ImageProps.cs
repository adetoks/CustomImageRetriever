using ImageMagick;

namespace ImageRetriever.Models
{
    public class ImageProps
    {
        public double DensityX { get; set; }
        public double DensityY { get; set; }
        public string Format { get; set; }
        public string ColorSpace { get; set; }
        public string Compression { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public int Quality { get; set; }
        public string Interlace { get; set; }
    }
}
