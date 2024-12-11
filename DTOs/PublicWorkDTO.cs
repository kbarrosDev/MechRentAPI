using System;
using MechRentAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace MechRentAPI.DTOs
{
	public class PublicWorkDTO
	{
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public int EstimatedHours { get; set; }
        public List<RentedExcavator> RentedExcavators { get; set; }
    }
}

