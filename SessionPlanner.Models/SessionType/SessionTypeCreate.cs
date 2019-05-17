using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SessionPlanner.Models.SessionType
{
    public class SessionTypeCreate
    {
        [Required]
        [Display(Name = "Name Of Session")]
        public string Name { get; set; }


        [Required]
        [Range(30, 150, ErrorMessage = "Please enter dollar amount between 30 and 150")]
        [Display(Name = "Price Per Hour")]
        public decimal PricePerHour { get; set; }
    }
}
