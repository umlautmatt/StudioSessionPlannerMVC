using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SessionPlanner.Data
{
    public class Session
    {
        [Key]
        public int SessionID { get; set; }


        [Required]
        public Guid OwnerID { get; set; }


        [Required]
        public int CustomerID { get; set; }


        [Required]
        public int SessionTypeID { get; set; }


        [Required]
        [Range(0800,0000, ErrorMessage="Please enter a start time between 8am and midnight")]
        public DateTimeOffset StartTime { get; set; }


        [Required]
        [Range(0100, 0900, ErrorMessage = "Please enter a start time between 8am and midnight")]
        public DateTimeOffset EndTime { get; set; }


        [Required(ErrorMessage="Please enter quantity of at least 1")]
        public int Quantity { get; set; }


        [Display(Name = "Enter any special requests here: ")]
        [MaxLength(1000, ErrorMessage = "Your special requests are limited to 1000 characters")]
        public string Extras { get; set; }


       
        public virtual SessionType SessionType { get; set; }
    }
}
