﻿namespace server.Models
{
    public class RoomAmenity
    {
        public Guid RoomId { get; set; }
        public Room Room { get; set; }

        public Guid AmenityId { get; set; }
        public Amenity Amenity { get; set; }
    }
}
