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

        // تسجيل الجداول (DbSets) بناءً على ملفات الـ SQL الخاصة بك
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Renter> Renters { get; set; }
        public DbSet<Lender> Lenders { get; set; }
        public DbSet<Item> Items { get; set; } //
        public DbSet<Booking> Bookings { get; set; } //
        public DbSet<Payment> Payments { get; set; } //
        public DbSet<Review> Reviews { get; set; } //
        public DbSet<Message> Messages { get; set; } //

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // إعدادات إضافية للتأكد من توافق المسميات مع SQL
            modelBuilder.Entity<Admin>().ToTable("Admins"); //
            modelBuilder.Entity<Item>().ToTable("item"); //
            modelBuilder.Entity<Booking>().ToTable("booking"); //
            modelBuilder.Entity<Payment>().ToTable("payment"); //
            modelBuilder.Entity<Review>().ToTable("review"); //
            modelBuilder.Entity<Message>().ToTable("message"); //
        }
    }
}