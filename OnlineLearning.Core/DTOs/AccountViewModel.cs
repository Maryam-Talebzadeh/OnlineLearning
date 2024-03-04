using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLearning.Core.DTOs
{
   public class RegisterViewModel
    {
        [Display(Name = "نام کاربری")]
        [Required(ErrorMessage ="{0} را وارد کنید.")]
        public string Username { get; set; }

        [Display(Name = "ایمیل")]
        [Required(ErrorMessage = "{0} را وارد کنید.")]
        [EmailAddress]
        public string Email { get; set; }

        [Display(Name = "کلمه عبور")]
        [Required(ErrorMessage = "{0} را وارد کنید.")]
        [PasswordPropertyText]
        public string Password { get; set; }

        [Display(Name = "تکرار کلمه عبور")]
        [Required(ErrorMessage = "{0} را وارد کنید.")]
        [PasswordPropertyText]
        [Compare("Password",ErrorMessage ="تکرار کلمه عبور با کلمه عبور مغایرت دارد.")]
        public string RePassword { get; set; }
    }

    public class LoginViewModel
    {
        [Display(Name = "ایمیل")]
        [Required(ErrorMessage = "{0} را وارد کنید.")]
        [EmailAddress]
        public string Email { get; set; }

        [Display(Name = "کلمه عبور")]
        [Required(ErrorMessage = "{0} را وارد کنید.")]
        [PasswordPropertyText]
        public string Password { get; set; }
    }
}
