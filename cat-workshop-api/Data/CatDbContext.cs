using cat_workshop_api.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace cat_workshop_api.Data
{
    public class CatDbContext : DbContext
    {
        public CatDbContext(DbContextOptions<CatDbContext> options) : base(options) 
        { 
        }

        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Comment> Comments { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // user เริ่มต้น
            modelBuilder.Entity<User>().HasData(
                new User { UserId = 1, Username = "admin", Password = "123456" , FirstName = "admin" , LastName = "Li"},
                new User { UserId = 2, Username = "admin2", Password = "123456", FirstName = "admin2", LastName = "Lily" }
            );
        }
    }
}
