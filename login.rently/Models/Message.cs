namespace login.rently.Models
{
    public class Message
    {
        public int id { get; set; }
        public string messagetext { get; set; } = string.Empty;
        public DateTime timestamp { get; set; } = DateTime.Now;

        // الربط مع المؤجر (مين اللي بعت أو استقبل)
        public int lenderid { get; set; }
        public Lender? lender { get; set; }

        // الربط مع المستأجر (الطرف التاني في المحادثة)
        public int renterid { get; set; }
        public Renter? renter { get; set; }
    }
}
