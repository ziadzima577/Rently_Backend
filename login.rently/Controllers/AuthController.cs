using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using login.rently.Data;
using login.rently.Models;

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

        // 1. تسجيل أدمن جديد (Register)
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] AdminRegisterDto model)
        {
            // التأكد إن الإيميل مش موجود قبل كدة
            if (await _context.Admins.AnyAsync(a => a.Email == model.Email))
            {
                return BadRequest("هذا البريد الإلكتروني مسجل بالفعل.");
            }

            var newAdmin = new Admin
            {
                FullName = model.FullName,
                Email = model.Email,
                PasswordHash = model.Password, // بنستخدم PasswordHash عشان يطابق الـ SQL
                CreatedAt = DateTime.Now,
                IsActive = true
            };

            _context.Admins.Add(newAdmin);
            await _context.SaveChangesAsync();

            return Ok(new { message = "تم تسجيل الأدمن بنجاح!" });
        }

        // 2. تسجيل الدخول (Login)
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto model)
        {
            // البحث باستخدام UserId و PasswordHash المطابقين للـ SQL
            var user = await _context.Admins
                .FirstOrDefaultAsync(a => a.Email == model.Email && a.PasswordHash == model.Password);

            if (user == null)
            {
                return Unauthorized("الإيميل أو كلمة المرور غير صحيحة.");
            }

            return Ok(new { 
                message = "تم تسجيل الدخول بنجاح", 
                adminId = user.UserId, // تم التعديل لـ UserId
                fullName = user.FullName 
            });
        }
    }

    // كلاس وسيط لعملية التسجيل (عشان الـ Swagger يطلب بيانات محددة بس)
    public class AdminRegisterDto
    {
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}