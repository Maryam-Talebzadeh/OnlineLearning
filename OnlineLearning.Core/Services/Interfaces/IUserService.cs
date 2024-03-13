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
        public UserViewModel GetUserById(int id);
        public UserViewModel GetUserByActiveCode(string activeCode);
        public bool UpdateUser(UserViewModel user);

        #region UserPanel

        public InformationUserViewModel GetUserInformation(string userName);
        public SidebarUserPanelViewModel GetUserInformationForSideBar(string userName);
        public EditProfileViewModel GetDataForEditProfileUser(string userName);
        public void EditProfile(string userName, EditProfileViewModel profile);
        public bool CompareOldPassword(string userName, string password);
        public void ChangeUserPassword(string userName, string newPassword);

        #endregion
    }
}
