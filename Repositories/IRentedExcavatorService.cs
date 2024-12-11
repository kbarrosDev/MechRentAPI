using System;
using MechRentAPI.Models;
using MechRentAPI.DTOs;


namespace MechRentAPI.Repositories
{
    public interface IRentedExcavatorService
    {
        Task<IEnumerable<RentedExcavatorDTO>> GetAllRentedExcavatorsAsync();
        Task<RentedExcavatorDTO> GetRentedExcavatorByIdAsync(int id);
        Task<IEnumerable<RentedExcavatorDTO>> GetRentedExcavatorsByPublicWorkIdAsync(int publicWorkId);
        Task AddRentedExcavatorAsync(RentedExcavatorDTO rentedExcavator);
        Task UpdateRentedExcavatorAsync(RentedExcavatorDTO rentedExcavator);
        Task DeleteRentedExcavatorAsync(int id);
    }
}

