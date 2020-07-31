using DoctorAppointment.Models;
using DoctorAppointment.Models.Context;
using DoctorAppointment.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Mapping;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoctorAppointment.Controllers
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
            Appointment ap = null;
            try
            {
                if (!ModelState.IsValid)
                {
                    return View();
                }
                else
                {
                    ap = apmgr.MakeApppointment(apmt);
                    return RedirectToAction("SuccessAppointment",new { id = ap.AID });
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("*", ex.Message);
                return View();
            }
        }

        public ActionResult SuccessAppointment(int id) {
            Appointment ap = apmgr.GetAppointment(id);
            return View(ap);
        }
    }
}