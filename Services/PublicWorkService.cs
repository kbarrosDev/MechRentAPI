using System;
using AutoMapper;
using MechRentAPI.DTOs;
using MechRentAPI.Models;
using MechRentAPI.Repositories;

namespace MechRentAPI.Services
{
    public class PublicWorkService : IPublicWorkService
    {
        private readonly IPublicWorkRepository _repository;
        private readonly IMapper _mapper;

        public PublicWorkService(IPublicWorkRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PublicWorkDTO>> GetAllPublicWorksAsync()
        {
            var publicWorks = await _repository.GetAllPublicWorksAsync();
            return _mapper.Map<IEnumerable<PublicWorkDTO>>(publicWorks);
        }

        public async Task<PublicWorkDTO> GetPublicWorkByIdAsync(int id)
        {
            var publicWork = await _repository.GetPublicWorkByIdAsync(id);
            return _mapper.Map<PublicWorkDTO>(publicWork);
        }

        public async Task<PublicWorkDTO> GetPublicWorkWithRentedExcavatorsAsync(int id)
        {
            var publicWork = await _repository.GetPublicWorkWithRentedExcavatorsAsync(id);
            return _mapper.Map<PublicWorkDTO>(publicWork);
        }

        public async Task AddPublicWorkAsync(PublicWorkDTO publicWorkDto)
        {
            var publicWork = _mapper.Map<PublicWork>(publicWorkDto);
            await _repository.AddPublicWorkAsync(publicWork);
        }

        public async Task UpdatePublicWorkAsync(int id, PublicWorkDTO publicWorkDto)
        {
            var existingPublicWork = await _repository.GetPublicWorkByIdAsync(id);
            if (existingPublicWork == null)
            {
                throw new KeyNotFoundException("Public Work not found");
            }

            _mapper.Map(publicWorkDto, existingPublicWork);
            await _repository.UpdatePublicWorkAsync(existingPublicWork);
        }

        public async Task DeletePublicWorkAsync(int id)
        {
            await _repository.DeletePublicWorkAsync(id);
        }
    }
}

