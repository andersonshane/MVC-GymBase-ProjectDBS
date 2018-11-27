using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace MVC_GymBase_ProjectDBS.Models
{
    [Table("Booking")]
    public class Booking
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)] // since you set the IDs in code
        public int BookingIDModels { get; set; }
        public int GymIDModels { get; set; }

        public int MemberIDModels { get; set; }

        public string Date { get; set; }

        public string Time { get; set; }
    }
}