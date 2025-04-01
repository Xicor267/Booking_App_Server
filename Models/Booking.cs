namespace server.Models
{
    public class Booking
    {
        public int Id { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public int NumberOfGuests { get; set; }
        public int NumberOfChildren { get; set; }
        public int HotelId { get; set; }
        public Hotel Hotel { get; set; }
    }
}
