using DoctorAppointment.Models.Entities;
using NUnit.Framework;
using NUnit.Framework.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointmentUnitTest
{
    [TestFixture]
    public class AppointmentTest
    {
        [Test]
        public void Is_Appointment_Properties_Implemented() {
            Type t = typeof(Appointment);
            PropertyInfo[] props = t.GetProperties();
            
            Assert.AreEqual("AID",props[0].Name);
            Assert.AreEqual("Int32", props[0].PropertyType.Name);
            Assert.AreEqual("PatientID", props[1].Name);
            Assert.AreEqual("Int32", props[1].PropertyType.Name);
            Assert.AreEqual("APatient", props[2].Name);
            Assert.AreEqual("Patient", props[2].PropertyType.Name);
            Assert.AreEqual("ADate", props[3].Name);
            Assert.AreEqual("DateTime", props[3].PropertyType.Name);
            Assert.AreEqual("ATime", props[4].Name);
            Assert.AreEqual("DateTime", props[4].PropertyType.Name);
            Assert.AreEqual("AStatus", props[5].Name);
            Assert.AreEqual("AppointmentStatus", props[5].PropertyType.Name);

        }
    }
}
