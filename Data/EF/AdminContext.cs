using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.EF
{
    public class AdminContext :DbContext
    {
        public AdminContext()
        {
        }

        public AdminContext(DbContextOptions<AdminContext> options)
            : base(options)
        {
        }
        public DbSet<Account>  Accounts { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=DESKTOP-I7EOLFR\SQLEXPRESS;Database=AdminPortalDB;Trusted_Connection=True;");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.HasKey(e => e.AccId);

                entity.HasOne<Role>(s => s.Role)
                    .WithMany(g => g.Accounts)
                    .HasForeignKey(s => s.RoleId);
                entity.Property(x => x.Email).IsRequired();
                entity.Property(x => x.Password).IsRequired();
                entity.Property(x => x.RoleId).IsRequired();
            }
            );

        }
    }
}
