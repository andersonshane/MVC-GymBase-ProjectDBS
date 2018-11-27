using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
//Comment


namespace MVC_GymBase_ProjectDBS.Models
{
    [Table("Trainer")]
    public class Trainer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)] // since you set the IDs in code
        public int TrainerIDModels { get; set; }

        [Required(ErrorMessage = "First Name is required")]
        [StringLength(30, MinimumLength = 3,
            ErrorMessage = "Name Should be minimum 3 characters and a maximum of 30 characters")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        [StringLength(30, MinimumLength = 3,
            ErrorMessage = "Name Should be minimum 3 characters and a maximum of 30 characters")]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        [Phone]
        public string Phone { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public int Salary { get; set; }

        //one gym class to a trainer relationship
        public int? GymClassID { get; set; }
        public GymClasses GymClass { get; set; }
    }
}

