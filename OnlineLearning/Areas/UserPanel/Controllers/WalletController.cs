using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineLearning.Core.DTOs;
using OnlineLearning.Core.Services.Interfaces;

namespace OnlineLearning.Web.Areas.UserPanel.Controllers
{
    [Area("UserPanel")]
    [Authorize]
    public class WalletController : Controller
    {
        private readonly IUserService _userService;
        private readonly IWalletService _walletService;

        public WalletController(IUserService userService, IWalletService walletService)
        {
            _userService = userService;
            _walletService = walletService;
        }

        [Route("UserPanel/Wallet")]
        public IActionResult Index()
        {
            int userId = _userService.GetIdByUserName(User.Identity.Name);
            ViewBag.WalletList = _walletService.GetUserWalets(userId);
            return View();
        }

        [Route("UserPanel/Wallet")]
        [HttpPost]
        public IActionResult Index(ChargeWalletViewModel charge)
        {
            int userId = _userService.GetIdByUserName(User.Identity.Name);
            if (!ModelState.IsValid)
            {            
                ViewBag.WalletList = _walletService.GetUserWalets(userId);
                return View(charge);
            }

            var wallet = new WalletViewModel()
            {
                Amount = charge.Amount,
                Description = "شارژ حساب",
                RegisterDate = DateTime.Now,
                Type = 1
            };

            _walletService.ChargeWallet(wallet, userId);

           //Online Payment

            return View();
        }
    }
}
