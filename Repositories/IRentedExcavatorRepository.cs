using System;
using MechRentAPI.Models;

namespace MechRentAPI.Repositories
{
    public interface IRentedExcavatorRepository
    {
        Task<IEnumerable<RentedExcavator>> GetAllRentedExcavatorsAsync();
        Task<RentedExcavator> GetRentedExcavatorByIdAsync(int id);
        Task<IEnumerable<RentedExcavator>> GetRentedExcavatorsByPublicWorkIdAsync(int publicWorkId);
        Task AddRentedExcavatorAsync(RentedExcavator rentedExcavator);
        Task UpdateRentedExcavatorAsync(RentedExcavator rentedExcavator);
        Task DeleteRentedExcavatorAsync(int id);
    }
}

