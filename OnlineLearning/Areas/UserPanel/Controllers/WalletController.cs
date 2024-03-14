using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace OnlineLearning.Web.Areas.UserPanel.Controllers
{
    [Area("UserPanel")]
    [Authorize]
    public class WalletController : Controller
    {
        [Route("UserPanel/Wallet")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
