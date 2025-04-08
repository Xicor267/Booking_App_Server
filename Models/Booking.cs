using server.Models.Enum;

namespace server.Models
{
    public class Booking
    {
        public Guid BookingId { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public int NumberOfAdults { get; set; }
        public int NumberOfChildren { get; set; }
        public decimal TotalPrice { get; set; }
        public BookingStatus Status { get; set; }
        public DateTime BookingDate { get; set; }
        public string SpecialRequests { get; set; }

        public Guid UserId { get; set; }
        public User? User { get; set; }

        public Guid RoomId { get; set; }
        public Room? Room { get; set; }

        public Payment? Payment { get; set; }
    }
}
