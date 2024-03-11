using OnlineLearning.DataLayer.Context.EfCore;
using OnlineLearning.DataLayer.Entities;
using OnlineLearning.DataLayer.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLearning.DataLayer.Repositories
{

    public class UserRepository : IUserRepository
    {
        private readonly OnlineLearningContext _context;
        public UserRepository(OnlineLearningContext context)
        {
            _context = context;
        }

        public User AddUser(User user)
        {
            _context.Users.Add(user);
            return user;
        }

        public bool DeleteUser(User user)
        {
            try
            {
                _context.Users.Remove(user);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<User> GetAllUsers()
        {
            return _context.Users.ToList();
        }

        public User GetUserById(int id)
        {
            return _context.Users.SingleOrDefault(u => u.Id == id);
        }

        public bool IsExistEmail(string email)
        {
            return _context.Users.Any(u => u.Email == email);
        }

        public bool IsExistUserName(string userName)
        {
             return _context.Users.Any(u => u.Username == userName);;
        }

        public bool LoginUser(string email, string password)
        {

            if (_context.Users.Any(u => u.Email == email && u.Password == password))
                return true;

            return false;
        }

        public bool UpdateUser(User user)
        {
            try
            {
                _context.Users.Update(user);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
