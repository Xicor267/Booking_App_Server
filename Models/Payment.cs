using server.Models.Enum;

namespace server.Models
{
    public class Payment
    {
        public Guid PaymentId { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public PaymentStatus Status { get; set; }
        public PaymentMethod Method { get; set; }
        public string TransactionId { get; set; }
        public Guid BookingId { get; set; }
    }
}
