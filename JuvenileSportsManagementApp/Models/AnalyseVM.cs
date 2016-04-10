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
    public class AnalyseVM
    {
        [Required]
        [Display(Name = "Athlete ID")]
        public int AthleteID { get; set; }

        [Required]
        [Display(Name = "Athlete Name")]
        public string AthleteName { get; set; }

        [Required]
        [Display(Name = "Event Name")]
        public string EventName { get; set; }

        [Required]
        [Display(Name = "Event Type")]
        public string EventType { get; set; }

        [Required]
        [Display(Name = "Time Frame")]
        public string TimeFrame { get; set; }

        [Required]
        [Display(Name = "Results")]
        public double[] Results { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Result Dates")]
        public DateTime[] ResultDates { get; set; }

        [Required]
        [Display(Name = "Total Number of Results")]
        public int TotalNumResults { get; set; }

        [Required]
        [Display(Name = "Best Result")]
        public double BestResult { get; set; }

        [Required]
        [Display(Name = "Worst Result")]
        public double WorstResult { get; set; }

        [Required]
        [Display(Name = "Average Result")]
        public double AverageResult { get; set; }

        [Display(Name = "Target Result")]
        public double TargetResult { get; set; }
    }
}