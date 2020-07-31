using DoctorAppointment.Models.Context;
using DoctorAppointment.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Web;

namespace DoctorAppointment.Models
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

            var apDate = new DateTime(apmt.ADate.Year, apmt.ADate.Month, apmt.ADate.Day);
            var seq = cntx.Appointments.Where(a => DbFunctions.TruncateTime(a.ADate)==apDate.Date).ToList();
            if (seq.Count() >= 12)
            {
                throw new Exception("No Schedule is available");
            }
            if (seq.Count() <= 0)
            {
                apmt.ATime = new DateTime(1, 1, 2, 10, 0, 0);
            }
            else
            {
                apmt.ATime = cntx.Appointments.Max(a => a.ATime).AddMinutes(20.0);
            }
            if (cntx.Appointments.Count() <= 0)
            {
                apmt.AID = 1;
            }
            else
            {
                apmt.AID = cntx.Appointments.Max(a => a.AID) + 1;
            }
            cntx.Appointments.Add(apmt);
            cntx.Patients.Add(apmt.APatient);
            cntx.SaveChanges();
            return apmt;
        }

        public Appointment GetAppointment(int aid)
        {
            var seq = cntx.Appointments.Include("APatient").Where(a => a.AID == aid);
            if (seq.Count() <= 0)
            {
                return null;
            }
            return seq.Single(); ;
        }
    }
}