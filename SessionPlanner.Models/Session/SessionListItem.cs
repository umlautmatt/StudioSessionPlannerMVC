using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SessionPlanner.Models
{
    public class SessionListItem
    {
        public int SessionID { get; set; }

        [Display(Name ="Session Type")]
        public int SessionTypeID { get; set; }

        public string Name { get; set; }

        //[Display(Name="Customer")]
        //public Guid OwnerID { get; set; }

        [Display(Name="Start Time")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM} {0:hh:mm tt}", ApplyFormatInEditMode = true)]
        public DateTime StartTime { get; set; }

        [Display(Name="End Time")]
        public DateTime EndTime { get; set; }

        public decimal Price { get; set; }

        public decimal PricePerHour { get; set; }
    }
}
