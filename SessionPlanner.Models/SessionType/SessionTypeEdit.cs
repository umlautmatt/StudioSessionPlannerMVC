using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SessionPlanner.Models.SessionType
{
    public class SessionTypeEdit
    {
        [Required]
        [Display (Name="Session Type")]
        public int SessionTypeID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Price Per Hour")]
        public decimal PricePerHour { get; set; }

    }
}
