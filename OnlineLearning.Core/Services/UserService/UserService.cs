using OnlineLearning.Core.Convertors;
using OnlineLearning.Core.DTOs;
using OnlineLearning.Core.Services.UserService.Interfaces;
using OnlineLearning.DataLayer.Entities;
using OnlineLearning.DataLayer.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLearning.Core.Services.UserService
{
    internal class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public bool IsExistEmail(string email)
        {
           email = FixText.FixEmail(email);
           return _userRepository.IsExistEmail(email);
        }

        public bool IsExistUserName(string userName)
        {
            return _userRepository.IsExistUserName(userName);
        }

        public bool Login(UserViewModel login)
        {
           login.Email = FixText.FixEmail(login.Email);

            if (_userRepository.LoginUser(login.Email,login.Username))
                return true;

            return false;
        }

        public UserViewModel Register(RegisterViewModel register)
        {
            var user = new User()
            {
                Email = register.Email,
                Username = register.Username,
                Password = register.Password
            };

            user = _userRepository.AddUser(user);
            return new UserViewModel()
            {
                Id = user.Id,
                Email = user.Email,
                Password = user.Password,
                Username = user.Username,
                UserAvatar = user.UserAvatar,
                IsActive = user.IsActive,
                RegisterDate = user.RegisterDate
            };
        }
    }
}
