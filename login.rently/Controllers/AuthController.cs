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

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDto model)
        {
            string? email = null;
            string? phone = null;

            // تحديد نوع المدخل (إيميل أم هاتف)
            if (model.EmailOrPhone.Contains("@"))
            {
                email = model.EmailOrPhone.Trim().ToLower();
            }
            else
            {
                phone = model.EmailOrPhone.Trim();
            }

            // التحقق من التكرار لمنع Error 500
            if (email != null && await _context.Admins.AnyAsync(a => a.Email == email))
                return BadRequest("هذا الإيميل مسجل بالفعل.");

            if (phone != null && await _context.Admins.AnyAsync(a => a.PhoneNumber == phone))
                return BadRequest("رقم التليفون مسجل بالفعل.");

            // تجميع تاريخ الميلاد
            DateTime? birthDate = null;
            try
            {
                birthDate = new DateTime(model.BirthYear, GetMonthNumber(model.BirthMonth), model.BirthDay);
            }
            catch { /* في حال كان التاريخ غير صحيح */ }

            var newAdmin = new Admin
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = email ?? $"user_{Guid.NewGuid().ToString().Substring(0, 8)}@rently.com",
                PhoneNumber = phone,
                PasswordHash = model.Password,
                BirthDate = birthDate,
                Gender = model.Gender,
                CreatedAt = DateTime.Now
            };

            _context.Admins.Add(newAdmin);
            await _context.SaveChangesAsync();

            return Ok(new { message = "تم إنشاء حساب Rently بنجاح!" });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto model)
        {
            var user = await _context.Admins
                .FirstOrDefaultAsync(a =>
                    (a.Email == model.EmailOrPhone || a.PhoneNumber == model.EmailOrPhone)
                    && a.PasswordHash == model.Password);

            if (user == null) return Unauthorized("بيانات الدخول غير صحيحة.");

            return Ok(new { message = $"أهلاً بك يا {user.FirstName}", adminId = user.UserId });
        }

        // دالة مساعدة لتحويل اسم الشهر لرقم
        private int GetMonthNumber(string month)
        {
            return month.ToLower() switch
            {
                "january" or "1" => 1,
                "february" or "2" => 2,
                "march" or "3" => 3,
                "april" or "4" => 4,
                "may" or "5" => 5,
                "june" or "6" => 6,
                "july" or "7" => 7,
                "august" or "8" => 8,
                "september" or "9" => 9,
                "october" or "10" => 10,
                "november" or "11" => 11,
                "december" or "12" => 12,
                _ => 1 // القيمة الافتراضية شهر يناير
            };
        }
    }

    // الـ DTOs المحدثة بناءً على واجهة المستخدم
    public class RegisterRequestDto
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string EmailOrPhone { get; set; }
        public required string Password { get; set; }
        public int BirthDay { get; set; }
        public string BirthMonth { get; set; } = "January";
        public int BirthYear { get; set; }
        public string Gender { get; set; } = "Not Specified";
    }

    public class LoginRequestDto
    {
        public required string EmailOrPhone { get; set; }
        public required string Password { get; set; }
    }
}