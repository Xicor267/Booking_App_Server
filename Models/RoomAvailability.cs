namespace server.Models
{
    public class RoomAvailability
    {
        public Room Room { get; set; }
        public Hotel Hotel { get; set; }
        public decimal PriceForStay { get; set; }
        public bool IsAvailable { get; set; }
    }
}
