﻿namespace server.Models
{
    public class PendingUser
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
