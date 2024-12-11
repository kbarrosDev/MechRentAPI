using System;
using MechRentAPI.Repositories;
using MechRentAPI.Models;
using MechRentAPI.DTOs;
using AutoMapper;

namespace MechRentAPI.Services
{
    public class ExcavatorService : IExcavatorService
    {
        private readonly IExcavatorRepository _excavatorRepository;
        private readonly IMapper _mapper;

        public ExcavatorService(IExcavatorRepository excavatorRepository, IMapper mapper)
        {
            _excavatorRepository = excavatorRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ExcavatorDTO>> GetAllExcavatorsAsync()
        {
            var excavators = await _excavatorRepository.GetAllExcavatorsAsync();
            return _mapper.Map<IEnumerable<ExcavatorDTO>>(excavators);
        }

        public async Task<ExcavatorDTO> GetExcavatorByIdAsync(int id)
        {
            var excavator = await _excavatorRepository.GetExcavatorByIdAsync(id);
            return _mapper.Map<ExcavatorDTO>(excavator);
        }

        public async Task<IEnumerable<ExcavatorDTO>> GetExcavatorsNearingMaintenanceAsync()
        {
            var excavators = await _excavatorRepository.GetExcavatorsNearingMaintenanceAsync();
            return _mapper.Map<IEnumerable<ExcavatorDTO>>(excavators);
        }

        public async Task AddExcavatorAsync(ExcavatorDTO excavatorDto)
        {
            var excavator = _mapper.Map<Excavator>(excavatorDto);
            await _excavatorRepository.AddExcavatorAsync(excavator);
        }

        public async Task UpdateExcavatorAsync(int id, ExcavatorDTO excavatorDto)
        {
            var existingExcavator = await _excavatorRepository.GetExcavatorByIdAsync(id);
            if (existingExcavator == null)
            {
                throw new KeyNotFoundException("Excavator not found");
            }

            _mapper.Map(excavatorDto, existingExcavator);
            await _excavatorRepository.UpdateExcavatorAsync(existingExcavator);
        }
    }
}

