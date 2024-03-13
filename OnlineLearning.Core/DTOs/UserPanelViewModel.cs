using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLearning.Core.DTOs
{
    public class InformationUserViewModel
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public DateTime RegisterDate { get; set; }
        public int Wallet { get; set; } = 0;
        public string ImageName { get; set; }
    }

    public class SidebarUserPanelViewModel
    {
        public string Username { get; set; }
        public DateTime RegisterDate { get; set; }
        public string ImageName { get; set; }
    }

    public class EditProfileViewModel
    {
        [Display(Name = "نام کاربری")]
        [Required(ErrorMessage = "{0} را وارد کنید.")]
        public string Username { get; set; }

        [Display(Name = "ایمیل")]
        [Required(ErrorMessage = "{0} را وارد کنید.")]
        [EmailAddress]
        public string Email { get; set; }

        public IFormFile UserAvatar { get; set; }
        public string AvatarName { get; set; }
    }

    public class ChangePasswordViewModel
    {
        [Display(Name = "  کلمه عبور فعلی")]
        [Required(ErrorMessage = "{0} را وارد کنید.")]
        [PasswordPropertyText]
        public string OldPassword { get; set; }

        [Display(Name = "  کلمه عبور جدید")]
        [Required(ErrorMessage = "{0} را وارد کنید.")]
        [PasswordPropertyText]
        public string Password { get; set; }

        [Display(Name = "تکرار کلمه عبور جدید")]
        [Required(ErrorMessage = "{0} را وارد کنید.")]
        [PasswordPropertyText]
        [Compare("Password", ErrorMessage = "تکرار کلمه عبور با کلمه عبور مغایرت دارد.")]
        public string RePassword { get; set; }
    }
}
