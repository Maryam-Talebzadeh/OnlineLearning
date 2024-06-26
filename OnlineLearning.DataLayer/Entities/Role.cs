﻿using OnlineLearning.DataLayer.Entities.Permission;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLearning.DataLayer.Entities
{
    public class Role
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsDeleted { get; set; }

        #region Navigation Properties

        public virtual List<UserRole> UserRoles { get; set; }
        public List<RolePermission> RolePermissions { get; set; }

        #endregion
    }
}
