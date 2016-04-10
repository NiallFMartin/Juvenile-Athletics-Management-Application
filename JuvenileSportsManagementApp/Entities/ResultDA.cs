using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuvenileSportsManagementApp.Entities
{
    [Table("Results")]
    public class ResultDA
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        [Key]
        public int ResultID { get; set; }

        [Required]
        public DateTime DateOfResult { get; set; }

        //result will be the distance in metres for long jump, etc. and in seconds for 100m, etc.
        [Required]
        public double Result { get; set; }

        [Required]
        public int AthleteID { get; set; }

        [Required]
        public string AthleteName { get; set; }

        [Required]
        public int EventID { get; set; }

        [Required]
        public string EventName { get; set; }

        [Required]
        public bool IsDeleted { get; set; }

        //Relationships
        public virtual AthleteDA Athlete { get; set; }
        public virtual EventDA Event { get; set; }
    }
}