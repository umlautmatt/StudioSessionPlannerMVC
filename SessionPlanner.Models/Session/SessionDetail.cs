using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SessionPlanner.Models.Session
{
    public class SessionDetail
    {
        public int SessionID { get; set; }

        
        public int SessionTypeID { get; set; }

        [Display(Name="Session Type")]
        public string Name { get; set; }

        [Display(Name = "Start Time")]
        public DateTime StartTime { get; set; }

        [Display(Name = "End Time")]
        public DateTime EndTime { get; set; }

        [Display(Name = "Date Booked")]
        public DateTime CreatedUtc { get; set; }

        [Display(Name = "Date Changed/Updated")]
        public DateTime? ModifiedUtc { get; set; }

        public decimal Price { get; set; }

        [Display(Name = "Special Requests")]
        public string Extras { get; set; }
    }
}
