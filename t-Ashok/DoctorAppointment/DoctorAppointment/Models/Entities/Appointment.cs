using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DoctorAppointment.Models.Entities
{
    public class Appointment : IEquatable<Appointment>
    {
        [Key]
        [DisplayName("Appointment ID")]
        public virtual int AID { get; set; }

        public virtual int PatientID { get; set; }

        [ForeignKey("PatientID")]
        public virtual Patient APatient { get; set; }

        [DisplayName("Date")]
        [Required(ErrorMessage ="Please select appointment date.")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
        public virtual DateTime ADate { get; set; }

        [DisplayName("Time Slot")]
        [Column(TypeName ="datetime2")]
        [DisplayFormat(DataFormatString = "{0:hh:mm}")]
        public virtual DateTime ATime { get; set; }

        [DisplayName("Status")]
        public virtual AppointmentStatus AStatus { get; set; }

        public bool Equals(Appointment other)
        {
            return ((this.AID == other.AID) && (this.APatient.Equals(other.APatient)) && (this.ADate.Equals(other.ADate)) && (this.ATime.Equals(other.ATime)) && (this.AStatus.Equals(other.AStatus)));
        }
    }
}