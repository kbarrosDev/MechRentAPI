using System;
using MechRentAPI.Models;

namespace MechRentAPI.Repositories
{
    public interface IExcavatorRepository
    {
        Task<IEnumerable<Excavator>> GetAllExcavatorsAsync();
        Task<Excavator> GetExcavatorByIdAsync(int id);
        Task<IEnumerable<Excavator>> GetExcavatorsNearingMaintenanceAsync();
        Task AddExcavatorAsync(Excavator excavator);
        Task UpdateExcavatorAsync(Excavator excavator);
    }
}

