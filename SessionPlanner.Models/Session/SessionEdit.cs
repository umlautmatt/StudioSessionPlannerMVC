using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SessionPlanner.Models.Session
{
    public class SessionEdit
    {
        [Required]
        [Display(Name ="Session Type")]
        public int SessionTypeID { get; set; }

        [Required]
        public int SessionID { get; set; }

        //[Required]
        //public string Name { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Begin Date")]
        public DateTimeOffset StartDay { get; set; }

        [DataType(DataType.Time)]
        [Required]
        [Display(Name = "Start Time")]
        public DateTimeOffset StartTime { get; set; }


        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "End Date")]
        public DateTimeOffset EndDay { get; set; }

        [Required]
        [DataType(DataType.Time)]
        [Display(Name = "End Time")]
        public DateTimeOffset EndTime { get; set; }

        [Display(Name="Special Requests")]
        public string Extras { get; set; }
    }
}
