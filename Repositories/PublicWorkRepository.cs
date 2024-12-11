using System;
using Microsoft.EntityFrameworkCore;
using MechRentAPI.Data;
using MechRentAPI.Models;

namespace MechRentAPI.Repositories
{
    public class PublicWorkRepository : IPublicWorkRepository
    {
        private readonly MechRentDbContext _context;

        public PublicWorkRepository(MechRentDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PublicWork>> GetAllPublicWorksAsync()
        {
            return await _context.PublicWorks.ToListAsync();
        }

        public async Task<PublicWork> GetPublicWorkByIdAsync(int id)
        {
            return await _context.PublicWorks.FindAsync(id);
        }

        public async Task<PublicWork> GetPublicWorkWithRentedExcavatorsAsync(int id)
        {
            return await _context.PublicWorks
                .Include(pw => pw.RentedExcavators)
                .ThenInclude(re => re.Excavator)
                .FirstOrDefaultAsync(pw => pw.Id == id);
        }

        public async Task AddPublicWorkAsync(PublicWork publicWork)
        {
            await _context.PublicWorks.AddAsync(publicWork);
            await _context.SaveChangesAsync();
        }

        public async Task UpdatePublicWorkAsync(PublicWork publicWork)
        {
            _context.PublicWorks.Update(publicWork);
            await _context.SaveChangesAsync();
        }

        public async Task DeletePublicWorkAsync(int id)
        {
            var publicWork = await _context.PublicWorks.FindAsync(id);
            if (publicWork != null)
            {
                _context.PublicWorks.Remove(publicWork);
                await _context.SaveChangesAsync();
            }
        }
    }
}

