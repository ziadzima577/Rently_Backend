using System.ComponentModel.DataAnnotations;

namespace login.rently.Models
{
    public class LoginDto
    {
        [Required]
        public string Email { get; set; } = string.Empty; // تأكد أن الاسم مطابق لما نستخدمه في الـ Controller

        [Required]
        public string Password { get; set; } = string.Empty;
    }
}