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
    public class ResultVM
    {
        [Key]
        public int ResultID { get; set; }

        [Required]
        [Display(Name = "Date of Result")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DateOfResult { get; set; }

        //result will be the distance in metres for long jump, etc. and in seconds for 100m, etc.
        [Required]
        public double Result { get; set; }

        [Required]
        [Display(Name = "Athlete ID")]
        public int AthleteID { get; set; }

        [Required]
        [Display(Name = "Athlete")]
        public string AthleteName { get; set; }

        [Required]
        [Display(Name = "Event ID")]
        public int EventID { get; set; }


        [Required]
        [Display(Name = "Event Name")]
        public string EventName { get; set; }

        [Required]
        public bool IsDeleted { get; set; }
    }
}