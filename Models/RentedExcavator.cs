using System;
using System.ComponentModel.DataAnnotations;

namespace MechRentAPI.Models
{
	public class RentedExcavator
	{
        public int Id { get; set; }
        [Required]
        public int ExcavatorId { get; set; }
        public Excavator Excavator { get; set; }
        [Required]
        public int PublicWorkId { get; set; }
        public PublicWork PublicWork { get; set; }
        public int WorkedHours { get; set; }
    }
}

