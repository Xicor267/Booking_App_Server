namespace server.Models
{
    public class AvailabilityRequest
    {
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public int NumberOfAdults { get; set; }
        public int NumberOfChildren { get; set; }
        public Guid? HotelId { get; set; }
        public string Location { get; set; }
    }
}
