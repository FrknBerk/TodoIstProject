using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoIstProject.Entities.Concrete;

namespace TodoIstProject.DataAccess.Concrete
{
    public class ApplicationDbContext : IdentityDbContext<AppUser,UserRole,int>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("server=DESKTOP-L012VL5\\SQLEXPRESS;database=TodoProjectDb; integrated security = true;MultipleActiveResultSets=true");
            }
            base.OnConfiguring(optionsBuilder);
        }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TodoIstTask>().HasKey(x => x.Id);
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<AppUser>(b => b.ToTable("AspNetUsers"));
           

        }

        public DbSet<TodoIstTask> TodoIstTasks { get; set; }

        //public DbSet<AspNetRoles> AspNetRoles { get; set; }

        //public DbSet<AppUser> AppUsers { get; set; }
        //public DbSet<Login> Logins { get; set; }
        //public DbSet<AspNetUser> AspNetUsers { get; set; }
    }
}
