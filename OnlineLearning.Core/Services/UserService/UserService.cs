using OnlineLearning.Core.Convertors;
using OnlineLearning.Core.DTOs;
using OnlineLearning.Core.Generators;
using OnlineLearning.Core.Security;
using OnlineLearning.Core.Services.UserService.Interfaces;
using OnlineLearning.DataLayer.Entities;
using OnlineLearning.DataLayer.Repositories.Interfaces;
using OnlineLearning.DataLayer.UnitOfWork;
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
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
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
                ActiveCode = NameGenarators.GenerateUniqeCode(),
                Email = FixText.FixEmail(register.Email),
                IsActive = false,
                Username = register.Username,
                Password = PasswordHelper.EncodePasswordMd5(register.Password),
                RegisterDate = DateTime.Now,
            };

            user = _userRepository.AddUser(user);
            _unitOfWork.Save();

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
