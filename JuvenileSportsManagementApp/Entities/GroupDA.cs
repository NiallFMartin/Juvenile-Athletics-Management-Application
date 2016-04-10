using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuvenileSportsManagementApp.Entities
{
    [Table("Groups")]

    public class GroupDA
    {
        [Key]
        [Required]
        public int GroupID { get; set; }
        [Required]
        public string GroupName { get; set; }

        [Required]
        public bool IsDeleted { get; set; }

        //Relationships
        public virtual List<AthleteDA> Athletes { get; set; }
    }
}