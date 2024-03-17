using OnlineLearning.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLearning.DataLayer.Repositories.Interfaces
{
    public interface IUserRepository
    {
         public User AddUser(User user);
        public bool UpdateUser(User user);
        public bool DeleteUser(User user);
        public User GetUserById(int id);
        public List<User> GetAllUsers();
        public User LoginUser(string email, string password);
        public bool IsExistEmail(string email);
        public bool IsExistUserName(string userName);
        public bool ActiveAccount(string ActiveCode);
        public User GetUserByEmail(string email);
        public User GetUserByActiveCode(string activeCode);
        public User GetUserByName(string userName);
        public bool CompareOldPassword(string userName,  string password);
        public int GetIdByUserName(string userName);
        public List<User> SearchUsers(string filterEmail = "", string filterUserName = "");

        #region Role

        public List<Role> GetRoles();
        public void AddRolesToUser(List<int> Roles, int userId);

        #endregion
    }
}
