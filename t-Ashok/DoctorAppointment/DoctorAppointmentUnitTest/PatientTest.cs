using DoctorAppointment.Models.Entities;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointmentUnitTest
{
    [TestFixture]
    public class PatientTest
    {
        [Test]
        public void Is_Patient_Properties_Implemented()
        {
            Type t = typeof(Patient);
            PropertyInfo[] props = t.GetProperties();

            Assert.AreEqual("PID", props[0].Name);
            Assert.AreEqual("Int32", props[0].PropertyType.Name);
            Assert.AreEqual("FirstName", props[1].Name);
            Assert.AreEqual("String", props[1].PropertyType.Name);
            Assert.AreEqual("MiddleName", props[2].Name);
            Assert.AreEqual("String", props[2].PropertyType.Name);
            Assert.AreEqual("LastName", props[3].Name);
            Assert.AreEqual("String", props[3].PropertyType.Name);
            Assert.AreEqual("Gender", props[4].Name);
            Assert.AreEqual("String", props[4].PropertyType.Name);
            Assert.AreEqual("Mobile", props[5].Name);
            Assert.AreEqual("String", props[5].PropertyType.Name);
        }
    }
}
