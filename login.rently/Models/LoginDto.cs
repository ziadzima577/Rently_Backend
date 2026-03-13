using System.ComponentModel.DataAnnotations;

namespace login.rently.Models
{
    public class LoginDto
    {
        [Required]
        public string EmailOrPhone { get; set; }

        [Required]
        public string Password { get; set; }
    }
}