using ImageRetriever.Logging;
using System.Net;

namespace ImageRetriever.DataAccess
{
    public class SystemNetWebAccess : IWebAccess
    {
        private readonly ILogger logger;

        public SystemNetWebAccess(ILogger logger)
        {
            this.logger = logger;
        }

        public byte[] DownloadData(string dataUrl)
        {
            try
            {
                using (var client = new WebClient())
                {
                    return client.DownloadData(dataUrl);
                }
            }
            catch (WebException e)
            {
                logger.Error(e, "An error occured trying to download the resource.");
            }
            return new byte[0];
        }

        public bool IsImageUrl(string url)
        {
            try
            {
                var req = WebRequest.Create(url);
                req.Method = "HEAD";
                using (var resp = req.GetResponse())
                {
                    return resp.ContentType.ToLower().StartsWith("image/");
                }
            }
            catch (WebException e)
            {
                logger.Error(e, $"An error occured trying to read the header info - does '{url}' exist?");
            }
            return false;
        }
    }
}
