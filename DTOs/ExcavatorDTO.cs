using System;
using System.ComponentModel.DataAnnotations;

namespace MechRentAPI.DTOs
{
	public class ExcavatorDTO
	{
        public int Id { get; set; }
        
        public string Model { get; set; }
        
        public decimal CostPerHour { get; set; }
        
        public int MaintenanceHours { get; set; }
        public int CurrentHours { get; set; }
    }
}

