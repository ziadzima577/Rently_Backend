namespace login.rently.Models
{
    public class Review
    {
        public int id { get; set; }
        public DateTime date { get; set; }
        public string comment { get; set; } = string.Empty;

        // خليتها string زي ما أنت عاملها في الـ SQL بس ممكن تكون int للنجوم (1-5)
        public string rating { get; set; } = string.Empty;

        // الربط مع الحجز (عشان نعرف التقييم ده تبع أنهي عملية تأجير)
        public int bookingid { get; set; }
        public Booking? booking { get; set; }
    }
}
