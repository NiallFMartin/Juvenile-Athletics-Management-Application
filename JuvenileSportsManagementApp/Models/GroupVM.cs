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
    public class GroupVM
    {
        [Key]
        [Required]
        public int GroupID { get; set; }
        [Required]
        [Display(Name = "Group")]
        public string GroupName { get; set; }

        [Required]
        public bool IsDeleted { get; set; }
    }
}