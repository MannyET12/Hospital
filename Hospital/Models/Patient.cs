using System.ComponentModel.DataAnnotations;
using System.Security.Policy;

namespace Hospital.Models
{
    public class Patient
    {
        [Key]
        public int ID { get; set; }
        public int PatientID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateOnly DateofBirth { get; set; }
        public string Village { get; set; }
        public List<Session> Sessions { get; set; }
        public List<Appointments> Appointments { get; set; }
    }
}
