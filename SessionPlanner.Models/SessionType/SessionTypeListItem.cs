using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SessionPlanner.Models.SessionType
{
    public class SessionTypeListItem
    {
        public int SessionTypeID { get; set; }


        [Display(Name="Session Name")]
        public string Name { get; set; }


        [Display(Name = "Price Per Hour")]
        public decimal PricePerHour { get; set; }
    }
}
