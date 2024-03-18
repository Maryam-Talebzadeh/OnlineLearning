using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineLearning.DataLayer.Entities.Wallet;

namespace OnlineLearning.DataLayer.Entities
{
    public class User
    {
        public User()
        {
            
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string ActiveCode { get; set; }
        public bool IsActive { get; set; }
        public string UserAvatar { get; set; }
        public DateTime RegisterDate { get; set; }
        public bool IsDeleted { get; set; }

        #region Navigation Properties

        public virtual List<UserRole> UserRoles { get; set; }
        public virtual List<Wallet.Wallet> Wallets { get; set; }

        #endregion
    }
}
