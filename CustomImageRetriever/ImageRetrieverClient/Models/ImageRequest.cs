using System.ComponentModel.DataAnnotations;

namespace ImageRetriever.Models
{
    public class ImageRequest
    {
        [Required(ErrorMessage = "Image Url is required.")]
        [Url(ErrorMessage = "Image Url must be a valid url.")]
        public string url { get; set; }

    }
}
