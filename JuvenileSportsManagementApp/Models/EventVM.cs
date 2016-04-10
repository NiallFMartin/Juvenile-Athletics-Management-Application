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
    public class EventVM
    {
        [Key]
        public int EventID { get; set; }

        [Required]
        [Display(Name = "Event Name")]
        public string EventName { get; set; }

        [Required]
        [Display(Name = "Event Type")]
        public string EventType { get; set; }

        [Required]
        public bool IsDeleted { get; set; }

    }
}