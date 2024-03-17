using OnlineLearning.Core.DTOs;
using OnlineLearning.Core.Services.Interfaces;
using OnlineLearning.DataLayer.Entities;
using OnlineLearning.DataLayer.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLearning.Core.Services
{
    public class AdminService : IAdminService
    {
        private readonly IUserRepository _userRepository;

        public AdminService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public UsersForAdminViewModel GetUsers(int pageId = 1, string filterEmail = "", string filterUserName = "")
        {
            var users = _userRepository.SearchUsers(filterEmail, filterUserName);
            int take = 1;
            int skip = (pageId - 1) * take;

            var adminUsers = new UsersForAdminViewModel()
            {
                Users = users.Select(user =>
                new UserViewModel
                {
                    Id = user.Id,
                    Email = user.Email,
                    Password = user.Password,
                    IsActive = user.IsActive,
                    RegisterDate = user.RegisterDate,
                    UserAvatar = user.UserAvatar,
                    Username = user.Username
                }).Skip(skip).Take(take).ToList(),

                CurrentPage = pageId,
                PagesCount = users.Count() / take
            };

            return adminUsers;
        }
    }
}
