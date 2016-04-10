using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using System.ComponentModel;

namespace JuvenileSportsManagementApp.Models
{
    public class AthleteVM
    {
        [Key]
        public int AthleteID { get; set; }

        [Required]
        [Display(Name = "Athlete Name")]
        public string AthleteName { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Date of Birth")]
        public DateTime DateOfBirth { get; set;}

        [Required]
        [Display(Name = "Group ID")]
        public int GroupID { get; set; }

        [Required]
        [Display(Name = "Group")]
        public string GroupName { get; set; }

        [Required]
        public bool IsDeleted { get; set; }
    }
}