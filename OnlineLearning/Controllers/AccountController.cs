using Microsoft.AspNetCore.Mvc;
using OnlineLearning.Core.DTOs;
using OnlineLearning.Core.Services.Interfaces;

namespace OnlineLearning.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel register)
        {
            if (!ModelState.IsValid)
                return View(register);

            if (_userService.IsExistUserName(register.Username))
            {
                ModelState.AddModelError("Username", "این نام کاربری قبلا ثبت شده است. لطفا یک نام کاربری دیگر انتخاب کنید.");
                return View(register);
            }

            if (_userService.IsExistEmail(register.Email))
            {
                ModelState.AddModelError("Email", "این ایمیل قبلا ثبت شده است. لطفا یک ایمیل دیگر انتخاب کنید.");
                return View(register);
            }

            _userService.Register(register);
            return View("/Views/Home/Index.cshtml");
        }
    }
}
