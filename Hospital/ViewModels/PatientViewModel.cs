using Hospital.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Hospital.ViewModels
{
    public class PatientViewModel
    {
        public List<PatientData> patients;
        public List<Patient> Patients { get; set; }
    }

    public class PatientListViewModel
    {
        public List<PatientViewModel> Patients { get; set; }
        public string SearchQuery { get; set; } // Example of additional data
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
    }

}

public class PatientData
{
    [Key]
    public int ID { get; set; }
    public int PatientID { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateOnly DateofBirth { get; set; }
    public string Address { get; set; }
    public string Gender { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public List<Appointments> Appointments { get; set; }
}

public class AppointmentData
{

}

