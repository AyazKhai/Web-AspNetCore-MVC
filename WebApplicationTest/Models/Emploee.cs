using System.ComponentModel.DataAnnotations;

namespace WebApplicationTest.Models
{
    public class Emploee
    {
        public int Id { get; set; }

        [Display(Name = "First Name")]
        [Required(ErrorMessage = "Frst name is required.")]
        [MaxLength(25, ErrorMessage = "Max is 25")]
        public string FName { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Last name is required.")]
        [MaxLength(25, ErrorMessage = "Max is 25")]
        public string LName { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Email address is required.")]
        [EmailAddress(ErrorMessage = "Email address is not valid.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Hire Date")]
        [DataType(DataType.Date)]
        public DateTime? DateOfHire { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Birth Date")]
        [DataType(DataType.Date)]
        public DateTime? DateOfBirth { get; set; }

        [StringLength(100)]
        public string Position { get; set; }

        [Display(Name = "Street")]
        [StringLength(50)]
        public string Address { get; set; }

        public string City { get; set; }

        public string Region { get; set; }
    }
}
