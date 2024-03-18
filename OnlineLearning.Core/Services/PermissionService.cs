using OnlineLearning.Core.DTOs;
using OnlineLearning.Core.Services.Interfaces;
using OnlineLearning.DataLayer.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLearning.Core.Services
{
    public class PermissionService : IPermissionService
    {
        private readonly IUserRepository _userRepository;

        public PermissionService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void EditRoles(int userId, List<int> RolesId)
        {
            _userRepository.DeleteRoles(userId, RolesId);
            _userRepository.AddRolesToUser(RolesId, userId);
        }

        public List<RoleViewModel> GetRoles()
        {
           return _userRepository.GetRoles().Select(r => new RoleViewModel
            {
                Id = r.Id,
                Title = r.Title
            }).ToList();
        }
    }
}
