using Microsoft.EntityFrameworkCore;
using server.Models;

namespace server.Data
{
    public class HotelBookingDbContext : DbContext
    {
        public HotelBookingDbContext(DbContextOptions<HotelBookingDbContext> options) : base(options) { }

        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<VisitorCount> VisitorCounts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Hotel>()
                .Property(h => h.HotelId)
                .ValueGeneratedNever();

            modelBuilder.Entity<Room>()
                .Property(r => r.RoomId)
                .ValueGeneratedNever();

            modelBuilder.Entity<Booking>()
                .Property(b => b.BookingId)
                .ValueGeneratedNever();

            modelBuilder.Entity<User>()
                .Property(u => u.UserId)
                .ValueGeneratedNever();

            modelBuilder.Entity<Payment>()
                .Property(p => p.PaymentId)
                .ValueGeneratedNever();

            modelBuilder.Entity<Amenity>()
                .Property(a => a.AmenityId)
                .ValueGeneratedNever();

            modelBuilder.Entity<Room>()
                .HasMany(b => b.Bookings)
                .WithOne(b => b.Room)
                .HasForeignKey(b => b.RoomId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Hotel>()
                .HasMany(h => h.Rooms)
                .WithOne(r => r.Hotel)
                .HasForeignKey(r => r.HotelId);


            modelBuilder.Entity<RoomAmenity>()
                .HasKey(ra => new { ra.RoomId, ra.AmenityId });

            modelBuilder.Entity<HotelAmenity>()
                .HasKey(ha => new { ha.HotelId, ha.AmenityId });

            modelBuilder.Entity<User>()
                .HasMany(b => b.Bookings)
                .WithOne(b => b.User)
                .HasForeignKey(b => b.BookingId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<VisitorCount>()
                .Property(v => v.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<VisitorCount>()
                .HasData(new VisitorCount { Count = 0, LastUpdated = new DateTime(2023, 1, 1) });

            base.OnModelCreating(modelBuilder);
        }
    }
}
