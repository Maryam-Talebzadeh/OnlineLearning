using Microsoft.AspNetCore.Mvc;

namespace OnlineLearning.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return Content("Hello");
        }
    }
}
