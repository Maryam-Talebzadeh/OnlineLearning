using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLearning.DataLayer.Entities.Permission
{
    public class Permission
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int? ParentId { get; set; }

        [ForeignKey("ParentId")]
        public List<Permission> Permissions { get; set; }

        #region Relations

        public List<RolePermission> RolePermissions { get; set; }

        #endregion
    }
}
