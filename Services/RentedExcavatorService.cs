using System;
using AutoMapper;
using MechRentAPI.DTOs;
using MechRentAPI.Models;
using MechRentAPI.Repositories;

namespace MechRentAPI.Services
{
    public class RentedExcavatorService : IRentedExcavatorService
    {
        private readonly IRentedExcavatorRepository _repository;
        private readonly IExcavatorRepository _excavatorRepository;
        private readonly IMapper _mapper;

        public RentedExcavatorService(IRentedExcavatorRepository repository, IExcavatorRepository excavatorRepository, IMapper mapper)
        {
            _repository = repository;
            _excavatorRepository = excavatorRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<RentedExcavatorDTO>> GetAllRentedExcavatorsAsync()
        {
            var rentedExcavators = await _repository.GetAllRentedExcavatorsAsync();
            return _mapper.Map<IEnumerable<RentedExcavatorDTO>>(rentedExcavators);
        }

        public async Task<RentedExcavatorDTO> GetRentedExcavatorByIdAsync(int id)
        {
            var rentedExcavator = await _repository.GetRentedExcavatorByIdAsync(id);
            return _mapper.Map<RentedExcavatorDTO>(rentedExcavator);
        }

        public async Task<IEnumerable<RentedExcavatorDTO>> GetRentedExcavatorsByPublicWorkIdAsync(int publicWorkId)
        {
            var rentedExcavators = await _repository.GetRentedExcavatorsByPublicWorkIdAsync(publicWorkId);
            return _mapper.Map<IEnumerable<RentedExcavatorDTO>>(rentedExcavators);
        }

        //public async Task AddRentedExcavatorAsync(AddRentedExcavatorDTO rentedExcavatorDto)
        //{
        //    var rentedExcavator = _mapper.Map<RentedExcavator>(rentedExcavatorDto);
        //    await _repository.AddRentedExcavatorAsync(rentedExcavator);

        //    // Update the CurrentHours of the Excavator
        //    var excavator = await _excavatorRepository.GetExcavatorByIdAsync(rentedExcavatorDto.ExcavatorId);
        //    excavator.CurrentHours += rentedExcavatorDto.InitialWorkedHours;
        //    await _excavatorRepository.UpdateExcavatorAsync(excavator);
        //}

        //public async Task UpdateWorkedHoursAsync(int id, UpdateWorkedHoursDTO updateWorkedHoursDto)
        //{
        //    var rentedExcavator = await _repository.GetRentedExcavatorByIdAsync(id);
        //    if (rentedExcavator == null)
        //    {
        //        throw new KeyNotFoundException("Rented Excavator not found");
        //    }

        //    rentedExcavator.WorkedHours += updateWorkedHoursDto.AdditionalHours;
        //    await _repository.UpdateRentedExcavatorAsync(rentedExcavator);

        //    // Update the CurrentHours of the Excavator
        //    var excavator = await _excavatorRepository.GetExcavatorByIdAsync(rentedExcavator.ExcavatorId);
        //    excavator.CurrentHours += updateWorkedHoursDto.AdditionalHours;
        //    await _excavatorRepository.UpdateExcavatorAsync(excavator);
        //}

        public async Task DeleteRentedExcavatorAsync(int id)
        {
            await _repository.DeleteRentedExcavatorAsync(id);
        }

        public async Task<decimal> CalculateTotalCostAsync(int rentedExcavatorId)
        {
            var rentedExcavator = await _repository.GetRentedExcavatorByIdAsync(rentedExcavatorId);
            if (rentedExcavator == null)
            {
                throw new KeyNotFoundException("Rented Excavator not found");
            }

            return rentedExcavator.WorkedHours * rentedExcavator.Excavator.CostPerHour;
        }

        public Task AddRentedExcavatorAsync(RentedExcavatorDTO rentedExcavator)
        {
            throw new NotImplementedException();
        }

        public Task UpdateRentedExcavatorAsync(RentedExcavatorDTO rentedExcavator)
        {
            throw new NotImplementedException();
        }
    }
}

