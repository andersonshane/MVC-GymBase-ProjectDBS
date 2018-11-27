using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVC_GymBase_ProjectDBS.Models
{
    [Table("Facilites")]
    public class Facilities
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)] // since you set the IDs in code
        public int FacilityIDModels { get; set; }

        [Required(ErrorMessage = "Please enter Facility Name")]
        [StringLength(30, MinimumLength = 3,
            ErrorMessage = "Name Should be minimum 3 characters and a maximum of 30 characters")]
        public string Name { get; set; }

    }
}