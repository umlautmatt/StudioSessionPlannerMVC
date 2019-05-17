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
        public int SessionTypeID { get; set; }

        
        [Required]
        [DataType(DataType.DateTime)]
        //[Range(0800,0000, ErrorMessage="Please enter a start time between 8am and midnight")]
        public DateTime StartTime { get; set; }


        [Required]
        [DataType(DataType.DateTime)]
        //[Range(0100, 0900, ErrorMessage = "Please enter a start time between 8am and midnight")]
        public DateTime EndTime { get; set; }

        public decimal Price { get; set; }


        [Display(Name = "Enter any special requests here: ")]
        [MaxLength(1000, ErrorMessage = "Your special requests are limited to 1000 characters")]
        public string Extras { get; set; }

        public DateTimeOffset CreatedUtc { get; set; }

        public DateTimeOffset? ModifiedUtc { get; set; }

        public virtual SessionType SessionType { get; set; }
    }
}
