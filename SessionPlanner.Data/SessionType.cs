﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SessionPlanner.Data
{

    //CREATE, UPDATE, DELETE ONLY AVAILABLE FOR ADMIN ROLE
    public class SessionType
    {
        [Key]
        public int SessionTypeID { get; set; }


        [Required]
        public Guid OwnerID { get; set; }


        [Required]
        [Display(Name = "Type Of Session")]
        public string Name { get; set; }


        [Required]
        [Range(30, 150, ErrorMessage = "Please enter dollar amount between 30 and 150")]
        [Display(Name = "Price Per Hour")]
        public decimal PricePerHour { get; set; }


        //[Required]
        //public string Length { get; set; }

    }
}
