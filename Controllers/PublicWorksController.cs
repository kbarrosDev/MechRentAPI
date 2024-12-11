using System;
using Microsoft.AspNetCore.Mvc;
using MechRentAPI.Services;
using MechRentAPI.DTOs;
using MechRentAPI.Repositories;

namespace MechRentAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PublicWorksController : ControllerBase
    {
        private readonly IPublicWorkService _publicWorkService;

        public PublicWorksController(IPublicWorkService publicWorkService)
        {
            _publicWorkService = publicWorkService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PublicWorkDTO>>> GetAllPublicWorks()
        {
            var publicWorks = await _publicWorkService.GetAllPublicWorksAsync();
            return Ok(publicWorks);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PublicWorkDTO>> GetPublicWork(int id)
        {
            var publicWork = await _publicWorkService.GetPublicWorkByIdAsync(id);
            if (publicWork == null)
            {
                return NotFound();
            }
            return Ok(publicWork);
        }

        [HttpGet("{id}/rentedexcavators")]
        public async Task<ActionResult<PublicWorkDTO>> GetPublicWorkWithRentedExcavators(int id)
        {
            var publicWork = await _publicWorkService.GetPublicWorkWithRentedExcavatorsAsync(id);
            if (publicWork == null)
            {
                return NotFound();
            }
            return Ok(publicWork);
        }

        [HttpPost]
        public async Task<ActionResult> AddPublicWork(PublicWorkDTO publicWorkDto)
        {
            await _publicWorkService.AddPublicWorkAsync(publicWorkDto);
            return CreatedAtAction(nameof(GetPublicWork), new { id = publicWorkDto.Id }, publicWorkDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdatePublicWork(int id, PublicWorkDTO publicWorkDto)
        {
            try
            {
                await _publicWorkService.UpdatePublicWorkAsync(id, publicWorkDto);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePublicWork(int id)
        {
            await _publicWorkService.DeletePublicWorkAsync(id);
            return NoContent();
        }
    }
}

