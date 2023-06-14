using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using SMS.WebApp.Data.Models.DataModels;

namespace SMS.WebApp.Data
{
    public class SMSDbContext : IdentityDbContext
    {
        public SMSDbContext(DbContextOptions<SMSDbContext> options) : base(options)
        { 
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }
        public DbSet<Students> Students { get; set; }
    }
}