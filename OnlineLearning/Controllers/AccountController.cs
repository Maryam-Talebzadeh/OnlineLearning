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

        [Route("Register")]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [Route("Register")]
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

        [Route("Login")]
        public IActionResult Login()
            => View();

        [HttpPost]
        [Route("Login")]
        public IActionResult Login(LoginViewModel login)
        {
            if (!ModelState.IsValid)
                return View(login);

            var user = _userService.Login(login);

            if(user != null)
            {

                if (!user.IsActive)
                {
                    ModelState.AddModelError("Email", "حساب کاربری فعال نشده است. لطفا آن را فعال کنید.");
                    return View(login);
                }

                ViewBag.IsSuccess = true;
                //Login User
                return Redirect("/");
            }

            return View();
        }

        [Route("ActiveAccount")]
        public IActionResult ActiveAccount(string activeCode)
        {
            ViewBag.IsActive = _userService.ActiveAccount(activeCode);
            return View();
        }

    }
}
