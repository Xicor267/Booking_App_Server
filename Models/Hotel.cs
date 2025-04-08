namespace server.Models
{
    public class Hotel
    {
        public Guid HotelId { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public float Rating { get; set; }
        public string ImageUrl { get; set; }
        public List<Room?> Rooms { get; set; }
        public List<Review?> Reviews { get; set; }
        public List<HotelAmenity?> HotelAmenities { get; set; }
    }
}
