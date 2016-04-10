using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuvenileSportsManagementApp.Entities
{
    [Table("Athletes")]
    public class AthleteDA
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        [Key]
        public int AthleteID { get; set; }

        [Required]
        public string AthleteName { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public int GroupID { get; set; }

        [Required]
        public string GroupName { get; set; }

        [Required]
        public bool IsDeleted { get; set; }

        //Relationships
        
        [ForeignKey("GroupID")]
        public virtual GroupDA AgeGroup { get; set; }

        public virtual List<ResultDA> Results { get; set; }
    }
}