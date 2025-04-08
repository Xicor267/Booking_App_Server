﻿using Microsoft.EntityFrameworkCore;
using server.Data;
using server.Models;
using server.Repositories.Interfaces;

namespace server.Repositories.Implementations
{
    public class HotelRepository : IHotelRepository
    {
        private readonly HotelBookingDbContext _context;

        public HotelRepository(HotelBookingDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Hotel>> GetHotelsAsync() =>
            await _context.Hotels.ToListAsync();

        public async Task<Hotel?> GetHotelByIdAsync(Guid id) =>
            await _context.Hotels.FindAsync(id);

        public async Task AddHotelAsync(Hotel hotel) =>
            await _context.Hotels.AddAsync(hotel);

        public Task UpdateHotelAsync(Hotel hotel)
        {
            _context.Hotels.Entry(hotel).State = EntityState.Modified;
            return Task.CompletedTask;
        }

        public Task DeleteHotelAsync(Guid id)
        {
            var hotel = _context.Hotels.Find(id);

            if (hotel != null)  _context.Hotels.Remove(hotel);

            return Task.CompletedTask;
        }

        public async Task SaveAsync() =>
            await _context.SaveChangesAsync();
    }
}
