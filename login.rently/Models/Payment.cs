namespace login.rently.Models
{
    public class Payment
    {
        public int id { get; set; }
        public DateTime transactiondate { get; set; }
        public decimal amount { get; set; }
        public string status { get; set; } = "Pending";

        // العلاقات (Foreign Keys)
        public int bookingid { get; set; }
        public Booking? booking { get; set; }

        public int adminid { get; set; }
        public Admin? admin { get; set; }

        public int renterid { get; set; }
        public Renter? renter { get; set; }
    }
}
