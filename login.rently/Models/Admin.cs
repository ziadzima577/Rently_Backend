using System.ComponentModel.DataAnnotations;

namespace login.rently.Models
{
    public class Admin
    {
        [Key]
        public int UserId { get; set; } // مطابق لـ UserId في الـ SQL

        public string FullName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string? PhoneNumber { get; set; } // علامة استفهام لأنه ممكن يكون NULL

        public string PasswordHash { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public bool IsActive { get; set; } = true;

        // علاقات اختيارية (لو حابب تربط الأدمن بالـ Lenders والـ Renters كودياً)
        public ICollection<Lender>? Lenders { get; set; }
        public ICollection<Renter>? Renters { get; set; }
    }
}