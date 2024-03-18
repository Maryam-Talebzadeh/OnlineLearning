using OnlineLearning.Core.DTOs;
using OnlineLearning.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLearning.Core.Services.Interfaces
{
    public interface IPermissionService
    {
        #region Roles

        public List<RoleViewModel> GetRoles();
        public void EditRoles(int userId, List<int> RolesId);
        public int AddRole(RoleViewModel role);
        public RoleViewModel GetRoleById(int RoleId);
        public void UpdateRole(RoleViewModel role);
        public void DeleteRole(int roleId);

        #endregion
    }
}
