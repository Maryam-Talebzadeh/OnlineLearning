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
        private readonly IConfiguration _configuration;

        public WalletController(IUserService userService, IWalletService walletService, IConfiguration configuration)
        {
            _userService = userService;
            _walletService = walletService;
            _configuration = configuration;
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

          int walletId =  _walletService.ChargeWallet(wallet, userId);

            #region OnlinePayment

            var payment = new ZarinpalSandbox.Payment(charge.Amount);
            var res = payment.PaymentRequest("شارژ حساب", "https://localhost:7066/UserPanel/OnlinePayment/" + walletId, _configuration.GetValue<string>("EmailUserName"));
            if(res.Result.Status == 0 && res.Result.Status == 100)
            {
               return Redirect("https://SandBox.ZarinPal.Com/pg/StartPay/" + res.Result.Authority);
            }

            #endregion

            return View();
        }

        [Route("UserPanel/OnlinePayment/{id}")]
        public IActionResult OnlinePayment(int id,string Authority="notok",string status = "notok")
        {
            if (HttpContext.Request.Query["Status"] != ""
                && HttpContext.Request.Query["Status"].ToString().ToLower() == "ok"
                && HttpContext.Request.Query["Authority"] != "")
            {
                string authority = HttpContext.Request.Query["Authority"];
                var wallet = _walletService.GetWalletById(id);
                var payment = new ZarinpalSandbox.Payment(wallet.Amount);
                var res = payment.Verification(authority).Result;

                if(res.Status == 100)
                {
                    ViewBag.Code = res.RefId;
                    ViewBag.IsSuccess = true;
                    wallet.IsPaid = true;
                }
            }

            return View();
        }
    }
}
