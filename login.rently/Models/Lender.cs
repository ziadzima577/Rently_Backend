namespace login.rently.Models
{
    public class Lender
    {
        public int id { get; set; } // مطابق لـ id في SQL
        public string name { get; set; } = string.Empty; //
        public string email { get; set; } = string.Empty; //

        // خلي بالك إن الباسورد int زي ما أنت كاتبه في الـ SQL
        public string password { get; set; } = string.Empty;

        public string? phone { get; set; } //

        // الربط مع جدول الـ Admin الأساسي
        public int adminid { get; set; } //
        public Admin? admin { get; set; }
    }
}
