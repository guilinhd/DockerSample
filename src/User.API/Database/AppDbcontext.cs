using Microsoft.EntityFrameworkCore;
using User.API.Models;

namespace User.API.Database
{
    public class AppDbcontext : DbContext
    {
        public DbSet<Role> Roles { get; set; }

        public AppDbcontext(DbContextOptions<AppDbcontext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Role>()
                .ToTable("Role")
                .HasKey(r => r.Id);
        }
    }
}
