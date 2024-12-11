using System;
using MechRentAPI.Models;

namespace MechRentAPI.Repositories
{
    public interface IPublicWorkRepository
    {
        Task<IEnumerable<PublicWork>> GetAllPublicWorksAsync();
        Task<PublicWork> GetPublicWorkByIdAsync(int id);
        Task<PublicWork> GetPublicWorkWithRentedExcavatorsAsync(int id);
        Task AddPublicWorkAsync(PublicWork publicWork);
        Task UpdatePublicWorkAsync(PublicWork publicWork);
        Task DeletePublicWorkAsync(int id);
    }
}

