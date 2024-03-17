using OnlineLearning.Core.DTOs;
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

        #endregion
    }
}
