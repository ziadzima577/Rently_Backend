using System.ComponentModel.DataAnnotations;

namespace login.rently.Models
{
    public class Admin
    {
        [Key]
        public int UserId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string PasswordHash { get; set; } = string.Empty;

       
        public DateTime? BirthDate { get; set; }
        public string? Gender { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public bool IsActive { get; set; } = true;
    }
}