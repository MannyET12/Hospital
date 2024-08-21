using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design;
using System.Security.Policy;

namespace Hospital.Models
{
    public class Patient
    {
        [Key]
        public int ID { get; set; }
        [Display(Name = "Patient ID")]

        public string PatientID
        {
            get
            {
                if (ID <= 0)
                {
                    return "PAT-XXX"; // Temporary placeholder before the entity is saved
                }
                else if (ID < 10)
                {
                    return "PAT-0" + ID;
                }
                else
                {
                    return "PAT-" + ID;
                }
            }
        } 
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
        public string? GenderOther {  get; set; }

        [Display(Name = "Email Address")]
        public string? Email { get; set; }

        [Display(Name = "Phone Number")]
        public int Phone { get; set; }
        [Display(Name = "Creation Date")]

        [Required]
        public DateTime? CreationDate { get; set; }
       

        [Display(Name = "Appointments")]
        public List<Appointments> Appointments { get; set; } = new List<Appointments>();
    }

    public enum Gender
    {
        Male,
        Female,
        Other
    }

    public enum Status
    {
        Active,
        Inactive,
        Deceased
    }
}
