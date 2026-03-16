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
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Renter> Renters { get; set; }
        public DbSet<Lender> Lenders { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Message> Messages { get; set; }


    }
}