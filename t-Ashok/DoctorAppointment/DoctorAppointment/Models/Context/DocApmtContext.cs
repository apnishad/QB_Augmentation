using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using DoctorAppointment.Models.Entities;

namespace DoctorAppointment.Models.Context
{
    public class DocApmtContext : DbContext
    {
        public DocApmtContext() : base("ConStr") { 

        }
        
        public virtual DbSet<Appointment> Appointments { get; set; }

        public virtual DbSet<Patient> Patients { get; set; }

    }
}