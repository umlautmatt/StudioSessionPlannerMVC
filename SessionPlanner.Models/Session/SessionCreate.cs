using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SessionPlanner.Models
{
    public class SessionCreate
    {
        [Required]
        [Display(Name="Session Type")]
        public int SessionTypeID { get; set; }


        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Begin Date")]
        public DateTimeOffset StartDay { get; set; }

        [Required]
        [DataType(DataType.Time)]
        [Display(Name = "Start Time")]
        //[Range(0800, 0000, ErrorMessage = "Please enter a start time between 8am and midnight")]
        public DateTimeOffset StartTime { get; set; }


        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "End Date")]
        public DateTimeOffset EndDay { get; set; }

        [Required]
        [DataType(DataType.Time)]
        [Display(Name = "End Time")]
        //[Range(0100, 0900, ErrorMessage = "Please enter a start time between 8am and midnight")]
        public DateTimeOffset EndTime { get; set; }

        public decimal PricePerHour { get; set; }

        [Display(Name = "Special Requests ")]
        [MaxLength(1000, ErrorMessage = "Your special requests are limited to 1000 characters")]
        public string Extras { get; set; }


    }
}
