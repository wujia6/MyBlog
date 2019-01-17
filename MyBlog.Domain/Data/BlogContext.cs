using Microsoft.EntityFrameworkCore;
using MyBlog.IComm.IRepos;
using MyBlog.Domain.Entities;
using Microsoft.Extensions.Configuration;

namespace MyBlog.Domain.Data
{
    public class BlogContext: DbContext, IUnitOfWork
    {
        public BlogContext() : base() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder().SetBasePath(System.IO.Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            optionsBuilder.UseSqlServer(config.GetConnectionString("SqlConn"));
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasKey(e => e.Id);
            modelBuilder.Entity<Role>().HasMany(e => e.RolePermssions).WithOne(e => e.Role).HasForeignKey(e => e.Role.Id);

            modelBuilder.Entity<Permssion>().HasKey(e => e.Id);
            modelBuilder.Entity<Permssion>().HasMany(e => e.RolePermssions).WithOne(e => e.Permssion).HasForeignKey(e => e.Permssion.Id);

            modelBuilder.Entity<User>().HasKey(e => e.Id);
            modelBuilder.Entity<User>().HasOne(e => e.Role).WithMany(e => e.Users);

            base.OnModelCreating(modelBuilder);
        }

        public new DbSet<T> Set<T>() where T: class
        {
            return base.Set<T>();
        }
    }
}
