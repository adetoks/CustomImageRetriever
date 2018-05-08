namespace ImageRetriever.DataAccess
{
    public interface IWebAccess
    {
        bool IsImageUrl(string url);
        byte[] DownloadData(string dataUrl);
    }
}