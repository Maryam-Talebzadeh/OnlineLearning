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

        public DbSet<Wallet> Wallets { get; set; }
        public DbSet<WalletType> WalletTypes { get; set; }

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            #region Role

            modelBuilder.Entity<Role>().HasData(
                new Role()
                {
                    Id = 1,
                    Title = "مدیر سایت"

                },
                new Role()
                {
                    Id = 2,
                    Title = "مدرس"

                },
                new Role()
                {
                    Id = 3,
                    Title = "کاربر عادی"

                });

            #endregion

            base.OnModelCreating(modelBuilder);
        }
    }
}
