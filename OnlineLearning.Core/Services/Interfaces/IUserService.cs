using OnlineLearning.Core.DTOs;
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
        public bool Login(UserViewModel login);
        public bool IsExistUserName(string userName);
        public bool IsExistEmail(string email);
    }
}
