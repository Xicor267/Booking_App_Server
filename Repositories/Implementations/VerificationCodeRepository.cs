using Microsoft.EntityFrameworkCore;
using server.Data;
using server.Models;
using server.Repositories.Interfaces;

namespace server.Repositories.Implementations
{
    public class VerificationCodeRepository : IVerificationCodeRepository
    {
        private readonly HotelBookingDbContext _context;

        public VerificationCodeRepository(HotelBookingDbContext context)
        {
            _context = context;
        }

        public async Task AddVertificationCodeAsync(VerificationCode code)
        {
            await _context.VerificationCodes.AddAsync(code);
        }

        public async Task<VerificationCode> GetVerificationCodeAsync(string email, string code)
        {
            return await _context.VerificationCodes.FirstOrDefaultAsync(v => v.Email == email && v.Code == code && v.ExpiresAt > DateTime.UtcNow);
        }

        public async Task DeleteVerificationCodeAsync(Guid id)
        {
            var code = await _context.VerificationCodes.FindAsync(id);
            if (code != null)
            {
                _context.VerificationCodes.Remove(code);
            }
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
