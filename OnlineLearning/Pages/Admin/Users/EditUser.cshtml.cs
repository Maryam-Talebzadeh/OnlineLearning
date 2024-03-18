using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OnlineLearning.Core.DTOs;
using OnlineLearning.Core.Services;
using OnlineLearning.Core.Services.Interfaces;

namespace OnlineLearning.Web.Pages.Admin.Users
{
    public class EditUserModel : PageModel
    {

        private readonly IAdminService _adminService;
        private readonly IPermissionService _permissionService;

        public EditUserModel(IAdminService adminService, IPermissionService permissionService)
        {
            _adminService = adminService;
            _permissionService = permissionService;
        }

        [BindProperty]
        public EditUserViewModel EditUserViewModel { get; set; }

        public void OnGet(int id)
        {
            EditUserViewModel = _adminService.GetUserForShowInEditMode(id);
            ViewData["Roles"] = _permissionService.GetRoles();
        }

        public IActionResult OnPost(List<int> SelectedRoles)
        {
            if(!ModelState.IsValid)
            {
                EditUserViewModel = _adminService.GetUserForShowInEditMode(EditUserViewModel.Id);
                ViewData["Roles"] = _permissionService.GetRoles();
                return Page();
            }

            if(SelectedRoles.Count == 0)
            {
                SelectedRoles = new List<int>() { 3 };
            }

            _permissionService.EditRoles(EditUserViewModel.Id, SelectedRoles);
            _adminService.EditUser(EditUserViewModel);

            return RedirectToPage("Index");
        }
    }
}
