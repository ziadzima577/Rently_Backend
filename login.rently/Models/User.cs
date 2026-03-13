using System.ComponentModel.DataAnnotations;

namespace login.rently.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required]
        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        [Required]
        public string PasswordHash { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public string? PasswordResetToken { get; set; } // الكود اللي هنبعته
        public DateTime? ResetTokenExpires { get; set; } // وقت انتهاء الكود (مثلاً بعد 10 دقائق)
    }
}