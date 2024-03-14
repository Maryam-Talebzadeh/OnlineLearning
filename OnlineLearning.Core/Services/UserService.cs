using Microsoft.Win32;
using OnlineLearning.Core.Convertors;
using OnlineLearning.Core.DTOs;
using OnlineLearning.Core.Generators;
using OnlineLearning.Core.Security;
using OnlineLearning.Core.Services.Interfaces;
using OnlineLearning.DataLayer.Entities;
using OnlineLearning.DataLayer.Repositories.Interfaces;
using OnlineLearning.DataLayer.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLearning.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWalletService _walletService;

        public UserService(IUserRepository userRepository, IUnitOfWork unitOfWork, IWalletService walletService)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
            _walletService = walletService;
        }

        public bool ActiveAccount(string ActiveCode)
        {

            if(_userRepository.ActiveAccount(ActiveCode))
            {
                _unitOfWork.Save();
                return true;
            }

            return false;
        }

        public void ChangeUserPassword(string userName, string newPassword)
        {
            var user = _userRepository.GetUserByName(userName);
            user.Password = PasswordHelper.EncodePasswordMd5(newPassword);
            _userRepository.UpdateUser(user);
            _unitOfWork.Save();
        }

        public bool CompareOldPassword(string userName, string password)
        {
            var hashedPassword = PasswordHelper.EncodePasswordMd5(password);
            return _userRepository.CompareOldPassword(userName,hashedPassword);
        }

        public void EditProfile(string userName, EditProfileViewModel profile)
        {
            var user = _userRepository.GetUserByName(userName);

            if(profile.UserAvatar != null)
            {
                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "UserAvatars");

               if(profile.AvatarName != "DefaultAvatar.jpg")
                    {
                    if (File.Exists(Path.Combine(path, profile.AvatarName)))
                        File.Delete(Path.Combine(path, profile.AvatarName));
                }

                profile.AvatarName = user.Id + Path.GetExtension(profile.UserAvatar.FileName);
                path = Path.Combine(path, profile.AvatarName);

                using(FileStream stream = new FileStream(path,FileMode.Create))
                {
                    profile.UserAvatar.CopyTo(stream);
                }

            }

            user.Username = profile.Username;
            user.Email = profile.Email;
            user.UserAvatar = profile.AvatarName;

            _userRepository.UpdateUser(user);
            _unitOfWork.Save();
        }

        public EditProfileViewModel GetDataForEditProfileUser(string userName)
        {
            var user = GetUserInformation(userName);

            return new EditProfileViewModel()
            {
                Username = user.Username,
                Email = user.Email,
                AvatarName = user.ImageName
            };
        }

        public int GetIdByUserName(string userName)
        {
           return _userRepository.GetIdByUserName(userName);
        }

        public UserViewModel GetUserByActiveCode(string activeCode)
        {
            var user = _userRepository.GetUserByActiveCode(activeCode);

            var newUser = new UserViewModel()
            {
                Id = user.Id,
                Email = user.Email,
                Password = user.Password,
                IsActive = user.IsActive,
                RegisterDate = user.RegisterDate,
                UserAvatar = user.UserAvatar,
                Username = user.Username
            };

            return newUser;
        }

        public UserViewModel GetUserByEmail(string email)
        {
            email = FixText.FixEmail(email);
            var user = _userRepository.GetUserByEmail(email);

            var newUser = new UserViewModel()
            {
                Id = user.Id,
                Email = user.Email,
                Password = user.Password,
                IsActive = user.IsActive,
                RegisterDate = user.RegisterDate,
                UserAvatar = user.UserAvatar,
                Username = user.Username
            };

            return newUser;

        }

        public UserViewModel GetUserById(int id)
        {
            var user = _userRepository.GetUserById(id);

            var newUser = new UserViewModel()
            {
                Id = user.Id,
                Email = user.Email,
                Password = user.Password,
                IsActive = user.IsActive,
                RegisterDate = user.RegisterDate,
                UserAvatar = user.UserAvatar,
                Username = user.Username
            };

            return newUser;
        }

        public InformationUserViewModel GetUserInformation(string userName)
        {
            var user = _userRepository.GetUserByName(userName);


            return new InformationUserViewModel()
            {
                Username = user.Username,
                Email = user.Email,
                RegisterDate = user.RegisterDate,
                ImageName = user.UserAvatar,
                Wallet = _walletService.BallanceUserWallet(user.Id)
            };
        }

        public SidebarUserPanelViewModel GetUserInformationForSideBar(string userName)
        {
            var user = GetUserInformation(userName);

            return new SidebarUserPanelViewModel()
            {
                Username = user.Username,
                RegisterDate = user.RegisterDate,
                ImageName = user.ImageName
            };
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

        public UserViewModel Login(LoginViewModel login)
        {
            login.Email = FixText.FixEmail(login.Email);
            login.Password = PasswordHelper.EncodePasswordMd5(login.Password);
            var user = _userRepository.LoginUser(login.Email, login.Password);

            var newUser = new UserViewModel()
            {
                Id = user.Id,
                Email = user.Email,
                Password = user.Password,
                IsActive = user.IsActive,
                RegisterDate = user.RegisterDate,
                UserAvatar = user.UserAvatar,
                Username = user.Username
            };

            return newUser;
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
                UserAvatar = "DefaultAvatar.jpg" 
                
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
                RegisterDate = user.RegisterDate,
                ActiveCode = user.ActiveCode
            };
        }

        public bool UpdateUser(UserViewModel user)
        {
            if (_userRepository.GetUserById(user.Id) == null)
                return false;

            var dbUser = new User()
            {
                ActiveCode = user.ActiveCode,
                Email = FixText.FixEmail(user.Email),
                IsActive = user.IsActive,
                Username = user.Username,
                Password = PasswordHelper.EncodePasswordMd5(user.Password),
                UserAvatar = user.UserAvatar
            };

            _userRepository.UpdateUser(dbUser);
            _unitOfWork.Save();
            return true;
        }
    }
}
