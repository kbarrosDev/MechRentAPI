using System;
using Microsoft.EntityFrameworkCore;
using MechRentAPI.Data;
using MechRentAPI.Models;

namespace MechRentAPI.Repositories
{
    public class RentedExcavatorRepository : IRentedExcavatorRepository
    {
        private readonly MechRentDbContext _context;

        public RentedExcavatorRepository(MechRentDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<RentedExcavator>> GetAllRentedExcavatorsAsync()
        {
            return await _context.RentedExcavators
                .Include(re => re.Excavator)
                .Include(re => re.PublicWork)
                .ToListAsync();
        }

        public async Task<RentedExcavator> GetRentedExcavatorByIdAsync(int id)
        {
            return await _context.RentedExcavators
                .Include(re => re.Excavator)
                .Include(re => re.PublicWork)
                .FirstOrDefaultAsync(re => re.Id == id);
        }

        public async Task<IEnumerable<RentedExcavator>> GetRentedExcavatorsByPublicWorkIdAsync(int publicWorkId)
        {
            return await _context.RentedExcavators
                .Include(re => re.Excavator)
                .Where(re => re.PublicWorkId == publicWorkId)
                .ToListAsync();
        }

        public async Task AddRentedExcavatorAsync(RentedExcavator rentedExcavator)
        {
            await _context.RentedExcavators.AddAsync(rentedExcavator);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateRentedExcavatorAsync(RentedExcavator rentedExcavator)
        {
            _context.RentedExcavators.Update(rentedExcavator);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteRentedExcavatorAsync(int id)
        {
            var rentedExcavator = await _context.RentedExcavators.FindAsync(id);
            if (rentedExcavator != null)
            {
                _context.RentedExcavators.Remove(rentedExcavator);
                await _context.SaveChangesAsync();
            }
        }
    }
}

