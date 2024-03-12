using OnlineLearning.Core.DTOs;
using OnlineLearning.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLearning.Core.Services.Interfaces
{
    public interface IUserService
    {
        public UserViewModel Register(RegisterViewModel register);
        public UserViewModel Login(LoginViewModel login);
        public bool IsExistUserName(string userName);
        public bool IsExistEmail(string email);
        public bool ActiveAccount(string ActiveCode);
        public UserViewModel GetUserByEmail(string email);
        public UserViewModel GetUserByActiveCode(string activeCode);
        public bool UpdateUser(UserViewModel user);
    }
}
