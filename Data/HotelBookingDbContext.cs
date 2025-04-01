using Microsoft.EntityFrameworkCore;
using server.Models;

namespace server.Data
{
    public class HotelBookingDbContext : DbContext 
    {
        public HotelBookingDbContext(DbContextOptions<HotelBookingDbContext> options) : base(options) { }

        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        //public DbSet<User> Users { get; set; }
    }
}
