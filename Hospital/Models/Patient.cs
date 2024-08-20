using System.ComponentModel.DataAnnotations;
using System.Security.Policy;

namespace Hospital.Models
{
    public class Patient
    {
        [Key]
        public int ID { get; set; }
        [Display(Name = "Patient ID")]

        public int PatientID { get; set; }
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Middle Name")]
        public string? MiddleName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Display(Name = "Date of Birth")]

        public DateTime? DateofBirth { get; set; }
        [Display(Name = "Address")]

        public string Address { get; set; }
        [Display(Name = "Gender")]

        public string Gender { get; set; }

        [Display(Name = "Other")]
        public string GenderOther {  get; set; }

        [Display(Name = "Email Address")]
        public string Email { get; set; }

        [Display(Name = "Phone Number")]
        public int Phone { get; set; }      
        
        [Display(Name = "Appointments")]
        public List<Appointments> Appointments { get; set; }
    }
    
    public enum Gender
    {
        Male,
        Female,
        Other
    }
}
