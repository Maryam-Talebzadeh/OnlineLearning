using Microsoft.EntityFrameworkCore;
using OnlineLearning.DataLayer.Entities;
using OnlineLearning.DataLayer.Entities.Wallet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLearning.DataLayer.Context.EfCore
{
    public class OnlineLearningContext : DbContext
    {
        public OnlineLearningContext(DbContextOptions<OnlineLearningContext> options) : base(options)
        {
            
        }

        #region User

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }

        #endregion

        #region Wallet

        public DbSet<Wallet> Wallet { get; set; }
        public DbSet<WalletType> WalletType { get; set; }

        #endregion
    }
}
