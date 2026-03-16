namespace login.rently.Models
{
    public class Item
    {
        public int id { get; set; } // مطابق لـ id في SQL
        public string title { get; set; } = string.Empty;
        public string description { get; set; } = string.Empty;
        public string category { get; set; } = string.Empty;
        public bool availability { get; set; } // الـ bit في SQL بيتحول لـ bool
        public decimal priceperday { get; set; } // الـ decimal في SQL

        // الربط مع جدول المؤجر (Lender)
        public int lenderid { get; set; }
        public Lender? lender { get; set; }

        // الربط مع جدول الـ Admin الأساسي
        public int adminid { get; set; }
        public Admin? admin { get; set; }
    }
}
