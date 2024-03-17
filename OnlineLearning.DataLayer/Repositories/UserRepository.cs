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

        public void AddRolesToUser(List<int> Roles, int userId)
        {
            foreach(int id in Roles)
            {
                _context.UserRoles.Add(new UserRole()
                {
                    RoleId = id,
                    UserId = userId
                });
            }

            _context.SaveChanges();
        }

        public User AddUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
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

        public int GetIdByUserName(string userName)
        {
            return _context.Users.Where(u => u.Username == userName).Select(u => u.Id).Single();
        }

        public List<Role> GetRoles()
        {
            return _context.Roles.ToList();
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

        public List<User> SearchUsers(string filterEmail = "", string filterUserName = "")
        {
            IQueryable<User> users = _context.Users;

            if(!string.IsNullOrEmpty(filterEmail))
            {
                users = users.Where(u => u.Email.Contains(filterEmail));
            }

            if (!string.IsNullOrEmpty(filterUserName))
            {
                users = users.Where(u => u.Username.Contains(filterUserName));
            }

            return users.ToList();
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
