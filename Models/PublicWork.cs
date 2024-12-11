using System;
using System.ComponentModel.DataAnnotations;

namespace MechRentAPI.Models
{
	public class PublicWork
	{
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int EstimatedHours { get; set; }
        public List<RentedExcavator> RentedExcavators { get; set; }
    }
}

