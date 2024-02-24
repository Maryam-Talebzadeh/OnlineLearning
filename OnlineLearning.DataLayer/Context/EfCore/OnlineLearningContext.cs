using Microsoft.EntityFrameworkCore;
using OnlineLearning.DataLayer.Entities;
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

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
    }
}
