using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLearning.DataLayer.Entities
{
    public class UserRole
    {

        public UserRole()
        {
            
        }

        public int Id { get; set; }
        public int UserId { get; set; }
        public int RoleId { get; set; }

        #region Navigation Properties

        public virtual User User { get; set; }
        public virtual Role Role { get; set; }

        #endregion
    }
}
