﻿namespace server.Models
{
    public class User
    {
        public Guid UserId { get; set; } = Guid.NewGuid();
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public DateTime CreatedAt { get; set; }

        // Initialize Bookings with an empty list
        public List<Booking?> Bookings { get; set; } = new List<Booking?>();
    }
}
