using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OnlineLearning.Core.Services.Interfaces;

namespace OnlineLearning.Web.Pages.Admin.Users
{
    public class DeleteUserModel : PageModel
    {
        private readonly IAdminService _adminService;

        public DeleteUserModel(IAdminService adminService)
        {
            _adminService = adminService;
        }

        public IActionResult OnGet(int id)
        {
            _adminService.DeleteUser(id);
            return RedirectToPage("Index");
        }
    }
}
