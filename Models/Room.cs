namespace server.Models
{
    public class Room
    {
        public Guid RoomId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Capacity { get; set; }
        public int MaxAdults { get; set; }
        public int MaxChildren { get; set; }
        public bool IsAvailable { get; set; }
        public List<string> ImageUrls { get; set; }
        public Guid HotelId { get; set; }
        public Hotel? Hotel { get; set; }
        public List<RoomAmenity?> RoomAmenities { get; set; }
        public List<Booking?> Bookings { get; set; }
    }
}
