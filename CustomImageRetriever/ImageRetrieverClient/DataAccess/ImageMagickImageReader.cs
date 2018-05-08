using ImageMagick;
using ImageRetriever.Logging;
using ImageRetriever.Models;

namespace ImageRetriever.DataAccess
{
    public class ImageMagickImageReader : IImageReader
    {
        private readonly ILogger logger;

        public ImageMagickImageReader(ILogger logger)
        {
            this.logger = logger;
        }

        public ImageProps GetImageProperties(byte[] imgData)
        {
            ImageProps imageProps = null;
            try
            {
                MagickImageInfo imageInfo = new MagickImageInfo(imgData);

                imageProps = new ImageProps()
                {
                    DensityX = imageInfo.Density.X,
                    DensityY = imageInfo.Density.Y,
                    Format = imageInfo.Format.ToString(),
                    ColorSpace = imageInfo.ColorSpace.ToString(),
                    Compression = imageInfo.Compression.ToString(),
                    Height = imageInfo.Height,
                    Width = imageInfo.Width,
                    Quality = imageInfo.Quality,
                    Interlace = imageInfo.Interlace.ToString()
                };
                return imageProps;
            }
            catch (MagickException)
            {
                return imageProps;
            }
        }
    }
}
