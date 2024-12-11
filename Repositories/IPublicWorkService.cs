using System;
using MechRentAPI.Models;
using MechRentAPI.DTOs;

namespace MechRentAPI.Repositories
{
    public interface IPublicWorkService
    {
        Task<IEnumerable<PublicWorkDTO>> GetAllPublicWorksAsync();
        Task<PublicWorkDTO> GetPublicWorkByIdAsync(int id);
        Task<PublicWorkDTO> GetPublicWorkWithRentedExcavatorsAsync(int id);
        Task AddPublicWorkAsync(PublicWorkDTO publicWorkDto);
        Task UpdatePublicWorkAsync(int id, PublicWorkDTO publicWorkDto);
        Task DeletePublicWorkAsync(int id);
    }
}

