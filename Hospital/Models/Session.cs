using System.ComponentModel.DataAnnotations;

namespace Hospital.Models
{
    public class Session
    {
        [Key]
        public int ID { get; set; }
        public int SessionID { get; set; }
        public string SessionName { get; set; }
        public int patientID { get; set; }
        public Patient Patient { get; set; }
        public int UserID { get; set; }

        public User User { get; set; }

        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

    }
}
