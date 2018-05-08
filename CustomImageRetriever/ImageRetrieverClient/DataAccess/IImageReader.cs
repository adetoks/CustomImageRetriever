using ImageRetriever.Models;

namespace ImageRetriever.DataAccess
{
    public interface IImageReader
    {
        ImageProps GetImageProperties(byte[] imgData);
    }
}
