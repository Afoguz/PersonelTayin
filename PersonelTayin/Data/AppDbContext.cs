using Microsoft.EntityFrameworkCore;
using PersonelTayin.Entities;
using PersonelTayin.Models;

namespace PersonelTayin.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        { 

        }
        public DbSet<UserAccount> UserAccounts { get; set; }
        public DbSet<Adliye> Adliyes { get; set; }
        public DbSet<Basvuru> Basvurular { get; set; }
    

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}
