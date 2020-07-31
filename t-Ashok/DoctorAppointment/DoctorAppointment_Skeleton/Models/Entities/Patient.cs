using Antlr.Runtime;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DoctorAppointment_Skeleton.Models.Entities
{
    public class Patient : IEquatable<Patient>
    {
        //Implement the code as per specification given.

        public virtual bool Equals(Patient other)
        {
            return ((this.PID == other.PID) && (this.FirstName.Equals(other.FirstName)) && (this.MiddleName.Equals(other.MiddleName)) && (this.LastName.Equals(other.LastName)) && (this.Gender.Equals(other.Gender)) && (this.Mobile.Equals(other.Mobile)));
        }
    }
}