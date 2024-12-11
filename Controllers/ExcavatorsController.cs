using System;
using Microsoft.AspNetCore.Mvc;
using MechRentAPI.Services;
using MechRentAPI.DTOs;
using MechRentAPI.Repositories;

namespace MechRentAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExcavatorsController : ControllerBase
    {
        private readonly IExcavatorService _excavatorService;

        public ExcavatorsController(IExcavatorService excavatorService)
        {
            _excavatorService = excavatorService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ExcavatorDTO>>> GetAllExcavators()
        {
            var excavators = await _excavatorService.GetAllExcavatorsAsync();
            return Ok(excavators);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ExcavatorDTO>> GetExcavator(int id)
        {
            var excavator = await _excavatorService.GetExcavatorByIdAsync(id);
            if (excavator == null)
            {
                return NotFound();
            }
            return Ok(excavator);
        }

        [HttpGet("maintenance")]
        public async Task<ActionResult<IEnumerable<ExcavatorDTO>>> GetExcavatorsNearingMaintenance()
        {
            var excavators = await _excavatorService.GetExcavatorsNearingMaintenanceAsync();
            return Ok(excavators);
        }

        [HttpPost]
        public async Task<ActionResult> AddExcavator(ExcavatorDTO excavatorDto)
        {
            await _excavatorService.AddExcavatorAsync(excavatorDto);
            return CreatedAtAction(nameof(GetExcavator), new { id = excavatorDto.Id }, excavatorDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateExcavator(int id, ExcavatorDTO excavatorDto)
        {
            try
            {
                await _excavatorService.UpdateExcavatorAsync(id, excavatorDto);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}

