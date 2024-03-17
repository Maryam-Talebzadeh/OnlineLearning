using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OnlineLearning.Core.DTOs;
using OnlineLearning.Core.Services.Interfaces;

namespace OnlineLearning.Web.Pages.Admin.Users
{
    public class IndexModel : PageModel
    {
        private readonly IAdminService _adminService;

        public IndexModel(IAdminService adminService)
        {
            _adminService = adminService;
        }

        public UsersForAdminViewModel UsersForAdmin { get; set; }

        public void OnGet(int pageId =1, string filterEmail ="", string filterUserName = "")
        {
            UsersForAdmin = _adminService.GetUsers(pageId,filterEmail,filterUserName);
        }
    }
}
