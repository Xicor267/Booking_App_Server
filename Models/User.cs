namespace server.Models
{
    public class User
    {
        public Guid UserId { get; set; } = Guid.NewGuid();
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public List<Booking?> Bookings { get; set; }
    }
}
