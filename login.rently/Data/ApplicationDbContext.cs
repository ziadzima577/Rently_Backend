using Microsoft.EntityFrameworkCore;
using login.rently.Models;

namespace login.rently.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // هنا بنقوله اعملي جدول اسمه Users بناءً على الموديل اللي عملناه
        public DbSet<User> Users { get; set; }
    }
}