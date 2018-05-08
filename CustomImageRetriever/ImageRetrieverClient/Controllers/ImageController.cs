using ImageRetriever.DataAccess;
using ImageRetriever.Models;
using Microsoft.AspNetCore.Mvc;

namespace ImageRetriever.Controllers
{
    [Route("api/[controller]")]
    public class ImageController : Controller
    {
        private readonly IWebAccess webAccess;
        private readonly IImageReader imageReader;

        public ImageController(IWebAccess webAccess, IImageReader imageReader)
        {
            this.webAccess = webAccess;
            this.imageReader = imageReader;
        }

        public ActionResult Get(ImageRequest request)
        {
            if (!webAccess.IsImageUrl(request.url))
            {
                ModelState.AddModelError("url", $"Url must point to an image resource.");
                return BadRequest(ModelState);
            }

            var data = webAccess.DownloadData(request.url);
            var imgProps = imageReader.GetImageProperties(data);
            var imgResponse = new ImageResponse
            {
                ImageSource = request.url,
                ColorSpace = imgProps.ColorSpace,
                Compression = imgProps.Compression,
                DensityX = imgProps.DensityX,
                DensityY = imgProps.DensityY,
                Format = imgProps.Format,
                Height = imgProps.Height,
                Interlace = imgProps.Interlace,
                Quality = imgProps.Quality,
                Width = imgProps.Width
            };

            return Json(imgResponse);
        }
    }
}
