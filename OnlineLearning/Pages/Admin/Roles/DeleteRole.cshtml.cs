using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OnlineLearning.Core.DTOs;
using OnlineLearning.Core.Services.Interfaces;

namespace OnlineLearning.Web.Pages.Admin.Roles
{
    public class DeleteRoleModel : PageModel
    {
        private readonly IPermissionService _permissionService;

        public DeleteRoleModel(IPermissionService permissionService)
        {
            _permissionService = permissionService;
        }

        [BindProperty]
        public RoleViewModel Role { get; set; }

        public void OnGet(int id)
        {
            Role =  _permissionService.GetRoleById(id);
        }

        public IActionResult OnPost()
        {
            _permissionService.DeleteRole(Role.Id);
            return RedirectToPage("Index");
        }
    }
}
