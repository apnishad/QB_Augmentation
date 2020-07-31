using DoctorAppointment_Skeleton.Models;
using DoctorAppointment_Skeleton.Models.Context;
using DoctorAppointment_Skeleton.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Mapping;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoctorAppointment_Skeleton.Controllers
{
    public class AppointmentController : Controller
    {
        IAppointmentManager apmgr = null;

        public AppointmentController(IAppointmentManager apmgr) {
            this.apmgr = apmgr;
        }
        // GET: Appointment
        [HttpGet]
        [ActionName("MakeAppointment")]
        public ActionResult MakeAppointment()
        {
            return View();
        }

        [HttpPost]
        [ActionName("MakeAppointment")]
        public ActionResult MakeAppointment_Post([Bind(Exclude ="AID,ATime")]Appointment apmt) {
            //Implement the code as per specification given.
            return View();
        }

        public ActionResult SuccessAppointment(int id) {
            //Implement the code as per specification given.
            return View();
        }
    }
}