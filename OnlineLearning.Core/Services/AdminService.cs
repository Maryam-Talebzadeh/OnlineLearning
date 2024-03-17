﻿using AutoMapper;
using Microsoft.Win32;
using OnlineLearning.Core.Convertors;
using OnlineLearning.Core.DTOs;
using OnlineLearning.Core.Generators;
using OnlineLearning.Core.Security;
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

        public void AddRolesToUser(List<int> Roles, int userId)
        {
            _userRepository.AddRolesToUser(Roles, userId);
        }

        public int AddUser(CreateUserViewModel user)
        {
            var newUser = new User()
            {
                ActiveCode = NameGenarators.GenerateUniqeCode(),
                Email = FixText.FixEmail(user.Email),
                IsActive = true,
                Username = user.Username,
                Password = PasswordHelper.EncodePasswordMd5(user.Password),
                RegisterDate = DateTime.Now,
                UserAvatar = "DefaultAvatar.jpg"
            };

            if (user.UserAvatar != null)
            {
                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "UserAvatars");
                newUser.UserAvatar = NameGenarators.GenerateUniqeCode + Path.GetExtension(user.UserAvatar.FileName);
                path = Path.Combine(path, newUser.UserAvatar);

                using (FileStream stream = new FileStream(path, FileMode.Create))
                {
                    user.UserAvatar.CopyTo(stream);
                }

            }

            return _userRepository.AddUser(newUser).Id;

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
