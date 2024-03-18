using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OnlineLearning.Core.DTOs;
using OnlineLearning.Core.Services.Interfaces;

namespace OnlineLearning.Web.Pages.Admin.Roles
{
    public class IndexModel : PageModel
    {

        private readonly IPermissionService _permissionService;

        public IndexModel(IPermissionService permissionService)
        {
            _permissionService = permissionService;
        }

        public List<RoleViewModel> RolesList { get; set; }

        public void OnGet()
        {
            RolesList = _permissionService.GetRoles();
        }
    }
}
