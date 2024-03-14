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

        public bool ActiveAccount(string ActiveCode)
        {
           var user = _context.Users.SingleOrDefault(u =>  u.ActiveCode == ActiveCode);

            if (user == null || user.IsActive == true)
                return false;

            user.IsActive = true;
            user.ActiveCode = Guid.NewGuid().ToString(); // Cant reference to core layer and use it's classes because of the defects of this 3 layer architecture.
            return true;
        }

        public User AddUser(User user)
        {
            _context.Users.Add(user);
            return user;
        }

        public bool CompareOldPassword(string userName, string password)
        {
          return  _context.Users.Any(u => u.Username == userName && u.Password == password);
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

        public User GetUserByActiveCode(string activeCode)
        {
            return _context.Users.SingleOrDefault(u => u.ActiveCode == activeCode);
        }

        public User GetUserByEmail(string email)
        {
            return _context.Users.SingleOrDefault(u => u.Email == email);
        }

        public User GetUserById(int id)
        {
            return _context.Users.SingleOrDefault(u => u.Id == id);
        }

        public User GetUserByName(string userName)
        {
            return _context.Users.SingleOrDefault(u => u.Username == userName);
        }

        public bool IsExistEmail(string email)
        {
            return _context.Users.Any(u => u.Email == email);
        }

        public bool IsExistUserName(string userName)
        {
             return _context.Users.Any(u => u.Username == userName);;
        }

        public User LoginUser(string email, string password)
        {
            var user = _context.Users.SingleOrDefault(u => u.Email == email && u.Password == password);
            return user;
                
        }

        public bool UpdateUser(User user)
        {
            try
            {
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
