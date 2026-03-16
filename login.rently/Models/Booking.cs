namespace login.rently.Models
{
    public class Booking
    {
        public int id { get; set; }
        public DateTime startdate { get; set; }
        public DateTime enddate { get; set; }
        public decimal totalprice { get; set; }
        public string status { get; set; } = "Pending"; // حالة الحجز (مقبول، مرفوض، قيد الانتظار)

        // العلاقات (Foreign Keys)
        public int lenderid { get; set; }
        public Lender? lender { get; set; }

        public int adminid { get; set; }
        public Admin? admin { get; set; }

        public int itemid { get; set; }
        public Item? item { get; set; }

        public int renterid { get; set; }
        public Renter? renter { get; set; }
    }
}
