namespace server.Models
{
    public class Review
    {
        public Guid ReviewId { get; set; }
        public float Rating { get; set; }
        public string Comment { get; set; }
        public DateTime Date { get; set; }

        public Guid UserId { get; set; }
        public User User { get; set; }

        public Guid HotelId { get; set; }
        public Hotel Hotel { get; set; }
    }
}
