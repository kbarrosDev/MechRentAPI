using System;
using Microsoft.EntityFrameworkCore;
using MechRentAPI.Data;
using MechRentAPI.Models;

namespace MechRentAPI.Repositories
{
    public class ExcavatorRepository : IExcavatorRepository
    {
        private readonly MechRentDbContext _context;

        public ExcavatorRepository(MechRentDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Excavator>> GetAllExcavatorsAsync()
        {
            return await _context.Excavators.ToListAsync();
        }

        public async Task<Excavator> GetExcavatorByIdAsync(int id)
        {
            return await _context.Excavators.FindAsync(id);
        }

        public async Task<IEnumerable<Excavator>> GetExcavatorsNearingMaintenanceAsync()
        {
            return await _context.Excavators
                .Where(e => e.MaintenanceHours - e.CurrentHours <= 120)
                .ToListAsync();
        }

        public async Task AddExcavatorAsync(Excavator excavator)
        {
            await _context.Excavators.AddAsync(excavator);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateExcavatorAsync(Excavator excavator)
        {
            _context.Excavators.Update(excavator);
            await _context.SaveChangesAsync();
        }
    }
}

