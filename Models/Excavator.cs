using System;
using System.ComponentModel.DataAnnotations;

namespace MechRentAPI.Models
{
	public class Excavator
	{
        public int Id { get; set; }
        [Required]
        public string Model { get; set; }
        [Required]
        public decimal CostPerHour { get; set; }
        [Required]
        public int MaintenanceHours { get; set; }
        public int CurrentHours { get; set; }
    }
}

