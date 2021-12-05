using DOMAIN.Entities.Menus;
using DOMAIN.Entities.Users;
using Microsoft.EntityFrameworkCore;

namespace INFRASTRUCTURE.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        #region Table
        public virtual DbSet<Menu> Menus { get; set; }
        public virtual DbSet<MenuGroup> MenuGroups { get; set; }
        public virtual DbSet<MenuRole> MenuRoles { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<UserRole> UserRoles { get; set; }
        #endregion

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            modelBuilder.Entity<User>()
                .HasIndex(i => i.Username)
                .IsUnique();

            modelBuilder.Entity<User>()
                .HasIndex(i => i.Email)
                .IsUnique();

            modelBuilder.Entity<UserRole>()
                .HasIndex(i => i.UserId);

            modelBuilder.Entity<UserRole>()
                .HasIndex(i => i.RoleId);

            modelBuilder.Entity<MenuRole>()
                .HasIndex(i => i.MenuId);

            modelBuilder.Entity<MenuRole>()
                .HasIndex(i => i.RoleId);

        }

    }
}
