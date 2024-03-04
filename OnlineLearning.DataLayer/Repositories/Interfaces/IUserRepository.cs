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
        public bool LoginUser(string email, string password);
        public bool IsExistEmail(string email);
        public bool IsExistUserName(string userName);
    }
}
