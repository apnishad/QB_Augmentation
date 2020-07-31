using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DoctorAppointment_Skeleton.Models.Entities
{
    public class Appointment : IEquatable<Appointment>
    {

        //Implement the code as per specification given. 
        
        public bool Equals(Appointment other)
        {
            return ((this.AID == other.AID) && (this.APatient.Equals(other.APatient)) && (this.ADate.Equals(other.ADate)) && (this.ATime.Equals(other.ATime)) && (this.AStatus.Equals(other.AStatus)));
        }
    }
}