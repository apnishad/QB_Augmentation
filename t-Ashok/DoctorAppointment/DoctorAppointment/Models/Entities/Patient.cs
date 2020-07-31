using Antlr.Runtime;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DoctorAppointment.Models.Entities
{
    public class Patient : IEquatable<Patient>
    {
        [Key]
        public virtual int PID { get; set; }

        [DisplayName("First Name")]
        [Required(ErrorMessage ="Please enter first name.")]
        public virtual string FirstName { get; set; }

        [DisplayName("Middle Name")]
        [Required(ErrorMessage = "Please enter middle name.")]
        public virtual string MiddleName { get; set; }

        [DisplayName("Last Name")]
        [Required(ErrorMessage = "Please enter last name.")]
        public virtual string LastName { get; set; }

        [DisplayName("Gender")]
        [Required(ErrorMessage = "Please select gender.")]
        public string Gender { get; set; }

        [DisplayName("Mobile")]
        [Required(ErrorMessage = "Please enter mobile no.")]
        [RegularExpression(@"^((\+){1}91){1}[ ]{1}[1-9]{1}[0-9]{9}$", ErrorMessage ="Please enter valid mobile no.[+91 0000000000]")]
        public virtual string Mobile { get; set; }

        public virtual bool Equals(Patient other)
        {
            return ((this.PID == other.PID) && (this.FirstName.Equals(other.FirstName)) && (this.MiddleName.Equals(other.MiddleName)) && (this.LastName.Equals(other.LastName)) && (this.Gender.Equals(other.Gender)) && (this.Mobile.Equals(other.Mobile)));
        }
    }
}