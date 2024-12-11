using System;
using MechRentAPI.Models;
using MechRentAPI.DTOs;

namespace MechRentAPI.Repositories
{
    public interface IExcavatorService
    {
        Task<IEnumerable<ExcavatorDTO>> GetAllExcavatorsAsync();
        Task<ExcavatorDTO> GetExcavatorByIdAsync(int id);
        Task<IEnumerable<ExcavatorDTO>> GetExcavatorsNearingMaintenanceAsync();
        Task AddExcavatorAsync(ExcavatorDTO excavatorDto);
        Task UpdateExcavatorAsync(int id, ExcavatorDTO excavatorDto);
    }
}

