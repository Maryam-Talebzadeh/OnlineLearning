using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OnlineLearning.Core.DTOs;
using OnlineLearning.Core.Services.Interfaces;

namespace OnlineLearning.Web.Pages.Admin.Roles
{
    public class AddRoleModel : PageModel
    {
        private readonly IPermissionService _permissionService;

        public AddRoleModel(IPermissionService permissionServic)
        {
            _permissionService = permissionServic;
        }

        [BindProperty]
        public RoleViewModel Role { get; set; }

        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            int roleId = _permissionService.AddRole(Role);

            return RedirectToPage("Index");
        }
    }
}
