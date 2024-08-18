using System.ComponentModel.DataAnnotations;

namespace Hospital.Models
{
    public class Appointments
    {
        [Key]
        public int ID { get; set; }
        public int AppointmentID { get; set; }

        public Patient Patient { get; set; }



    }
}
