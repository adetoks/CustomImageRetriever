using ImageRetrieverService.Models;
using Microsoft.AspNetCore.Mvc;

namespace ImageRetrieverService.Controllers
{
    [Route("api/[controller]")]
    public class ImageController : Controller
    {

        // GET api/values/5
        //[HttpGet("{id}")]
        public ActionResult Get(string imageUrl)
        {
            return Json(new ImageResponse
            {
                ImageName = "value"
            });
        }
    }
}
