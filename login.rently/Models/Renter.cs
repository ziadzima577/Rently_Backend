namespace login.rently.Models
{
    public class Renter
    {
        public int id { get; set; } // مطابق لـ id في SQL
        public string name { get; set; } = string.Empty;
        public string email { get; set; } = string.Empty;

        // ملاحظة: أنت عامله int في الـ SQL بس الأفضل يكون string لو فيه تشفير
        // بس همشي مع طلبك حالياً
        public string password { get; set; } = string.Empty;

        public string? phone { get; set; }
        public bool verified { get; set; } // الـ bit في SQL بيتحول لـ bool هنا

        // الربط مع جدول الـ Admin (الـ Foreign Key)
        public int adminid { get; set; }
        public Admin? Admins { get; set; }
    }
}
