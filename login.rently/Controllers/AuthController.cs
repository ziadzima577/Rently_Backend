using Microsoft.AspNetCore.Mvc;
using login.rently.Data;
using login.rently.Models;
using Microsoft.EntityFrameworkCore;
using BCrypt.Net;

namespace login.rently.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AuthController(ApplicationDbContext context)
        {
            _context = context;
        }

       
        [HttpPost("register")]
        public async Task<IActionResult> Register(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return Ok("User Registered Successfully!");
        }

        
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginData)
        {
            
            var user = await _context.Users.FirstOrDefaultAsync(u =>
                (u.Email == loginData.EmailOrPhone || u.PhoneNumber == loginData.EmailOrPhone)
                && u.PasswordHash == loginData.Password);

            if (user == null)
            {
                return Unauthorized("بيانات الدخول غير صحيحة");
            }

            return Ok(new { message = "login succesfully ", userName = user.FullName });



        }

        [HttpPost("forgot-password")]
        public async Task<IActionResult> ForgotPassword(string email)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
            if (user == null) return BadRequest("الإيميل ده مش متسجل عندنا");

            
            var otpCode = new Random().Next(100000, 999999).ToString();

            user.PasswordResetToken = otpCode;
            user.ResetTokenExpires = DateTime.Now.AddMinutes(15); 

            await _context.SaveChangesAsync();

            
            return Ok(new { message = "تم توليد كود التحقق", code = otpCode });
        }

        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword(string email, string token, string newPassword)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);

            if (user == null || user.PasswordResetToken != token || user.ResetTokenExpires < DateTime.Now)
                return BadRequest("الكود غلط أو صلاحيته انتهت");

            
            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(newPassword);

            
            user.PasswordResetToken = null;
            user.ResetTokenExpires = null;

            await _context.SaveChangesAsync();
            return Ok("مبروك، الباسورد اتغير بنجاح!");
        }

    }
}