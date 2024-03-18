using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OnlineLearning.Core.DTOs;
using OnlineLearning.Core.Services.Interfaces;

namespace OnlineLearning.Web.Pages.Admin.Roles
{
    public class EditRoleModel : PageModel
    {
        private readonly IPermissionService _permissionService;

        public EditRoleModel(IPermissionService permissionService)
        {
            _permissionService = permissionService;
        }

        [BindProperty]
        public RoleViewModel Role { get; set; }

        public void OnGet(int id)
        {
            Role = _permissionService.GetRoleById(Role.Id);
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            _permissionService.UpdateRole(Role);

            return RedirectToPage("Index");
        }
    }
}
