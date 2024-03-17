using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OnlineLearning.Core.DTOs;
using OnlineLearning.Core.Services.Interfaces;

namespace OnlineLearning.Web.Pages.Admin.Users
{
    public class CreateUserModel : PageModel
    {
        private readonly IPermissionService _permissionService;
        private readonly IAdminService _adminService;

        public CreateUserModel(IPermissionService permissionService, IAdminService adminService)
        {
            _permissionService = permissionService;
            _adminService = adminService;
        }

        [BindProperty]
        public CreateUserViewModel CreateUser { get; set; }

        public void OnGet()
        {
            ViewData["Roles"] = _permissionService.GetRoles();
        }

        public IActionResult OnPost(List<int> SelectedRoles)
        {
            if (!ModelState.IsValid)
            {
                ViewData["Roles"] = _permissionService.GetRoles();
                return Page();
            }

            if(SelectedRoles.Count() == 0)
            {
                SelectedRoles = new List<int>() { 3 };
            }

            int userId = _adminService.AddUser(CreateUser);
            _adminService.AddRolesToUser(SelectedRoles, userId);

            return Redirect("/Admin/Users");
        }

                    
    }
}
