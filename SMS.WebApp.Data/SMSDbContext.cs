using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace SMS.WebApp.Data
{
    public class SMSDbContext : IdentityDbContext
    {
        public SMSDbContext(DbContextOptions<SMSDbContext> options) : base(options)
        { 
        }
    }
}