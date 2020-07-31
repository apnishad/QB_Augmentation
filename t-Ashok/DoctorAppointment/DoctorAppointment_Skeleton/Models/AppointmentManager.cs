using DoctorAppointment_Skeleton.Models.Context;
using DoctorAppointment_Skeleton.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Web;

namespace DoctorAppointment_Skeleton.Models
{
    public class AppointmentManager : IAppointmentManager
    {
        DocApmtContext cntx = null;
        public AppointmentManager(DocApmtContext cntx)
        {
            this.cntx = cntx;
        }

        public Appointment MakeApppointment(Appointment apmt)
        {
            //Implement the code as per specification given.
            
            return apmt;
        }

        public Appointment GetAppointment(int aid)
        {
            //Implement the code as per specification given.

            return null;
        }
    }
}