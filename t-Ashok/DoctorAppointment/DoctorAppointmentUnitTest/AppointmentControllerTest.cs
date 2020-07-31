using DoctorAppointment.Controllers;
using DoctorAppointment.Models;
using DoctorAppointment.Models.Context;
using DoctorAppointment.Models.Entities;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace DoctorAppointmentUnitTest
{
    [TestFixture]
    public class AppointmentControllerTest
    {
        List<Appointment> aptList = null;
        List<Patient> patList = null;
        Mock<DbSet<Appointment>> mockset1 = null;
        Mock<DbSet<Patient>> mockset2 = null;
        Mock<DocApmtContext> mockContext = null;
        Mock<AppointmentManager> mockIManager = null;
        
        AppointmentManager mgr = null;

        [SetUp]
        public void Initialize()
        {
            aptList = new List<Appointment>();
            patList = new List<Patient>();
            mockset1 = new Mock<DbSet<Appointment>>();
            mockset2 = new Mock<DbSet<Patient>>();
        }

        [Test]
        public void MakeAppointment_Post_Test() {
            mockset1.As<IQueryable>().Setup(a => a.Provider).Returns(aptList.AsQueryable().Provider);
            mockset1.As<IQueryable>().Setup(a => a.Expression).Returns(aptList.AsQueryable().Expression);
            mockset1.As<IQueryable>().Setup(a => a.ElementType).Returns(aptList.AsQueryable().ElementType);
            mockset1.As<IQueryable>().Setup(a => a.GetEnumerator()).Returns(aptList.AsQueryable().GetEnumerator());

            mockset2.As<IQueryable>().Setup(a => a.Provider).Returns(patList.AsQueryable().Provider);
            mockset2.As<IQueryable>().Setup(a => a.Expression).Returns(patList.AsQueryable().Expression);
            mockset2.As<IQueryable>().Setup(a => a.ElementType).Returns(patList.AsQueryable().ElementType);
            mockset2.As<IQueryable>().Setup(a => a.GetEnumerator()).Returns(patList.AsQueryable().GetEnumerator());

            mockContext = new Mock<DocApmtContext>();
            mockContext.Setup(a => a.Appointments).Returns(mockset1.Object);
            mockContext.Setup(a => a.Patients).Returns(mockset2.Object); 
            
            mockIManager = new Mock<AppointmentManager>(mockContext.Object);

            var controller = new AppointmentController(mockIManager.Object);

            var result = (RedirectToRouteResult)controller.MakeAppointment_Post(new Appointment { APatient = new Patient { FirstName = "Kush", MiddleName = "Ram", LastName = "Verma", Gender = "Male", Mobile = "9921304656" }, ADate = DateTime.Now.AddDays(1) });

            Assert.AreEqual("SuccessAppointment", result.RouteValues["action"]);
            Assert.AreEqual(1, result.RouteValues["id"]);
        }

        [Test]
        public void MakeAppointment_Post_LastofDay_Test()
        {
            Patient p1 = new Patient { PID = 1, FirstName = "Kush", MiddleName = "Ram", LastName = "Verma", Gender = "Male", Mobile = "9921304656" };
            Patient p2 = new Patient { PID = 2, FirstName = "Ramesh", MiddleName = "Ram", LastName = "Verma", Gender = "Male", Mobile = "9921304656" };
            Patient p3 = new Patient { PID = 3, FirstName = "Somesh", MiddleName = "Ram", LastName = "Verma", Gender = "Male", Mobile = "9921304656" };
            Patient p4 = new Patient { PID = 4, FirstName = "Rajesh", MiddleName = "Ram", LastName = "Verma", Gender = "Male", Mobile = "9921304656" };
            Patient p5 = new Patient { PID = 5, FirstName = "Ajesh", MiddleName = "Ram", LastName = "Verma", Gender = "Male", Mobile = "9921304656" };
            Patient p6 = new Patient { PID = 6, FirstName = "Dinesh", MiddleName = "Ram", LastName = "Verma", Gender = "Male", Mobile = "9921304656" };
            Patient p7 = new Patient { PID = 7, FirstName = "Indrajit", MiddleName = "Ram", LastName = "Verma", Gender = "Male", Mobile = "9921304656" };
            Patient p8 = new Patient { PID = 8, FirstName = "Ramjit", MiddleName = "Ram", LastName = "Verma", Gender = "Male", Mobile = "9921304656" };
            Patient p9 = new Patient { PID = 9, FirstName = "Ajit", MiddleName = "Ram", LastName = "Verma", Gender = "Male", Mobile = "9921304656" };
            Patient p10 = new Patient { PID = 10, FirstName = "Amit", MiddleName = "Ram", LastName = "Verma", Gender = "Male", Mobile = "9921304656" };
            Patient p11 = new Patient { PID = 11, FirstName = "Gaurav", MiddleName = "Ram", LastName = "Verma", Gender = "Male", Mobile = "9921304656" };
            Patient p12 = new Patient { FirstName = "Yuvraj", MiddleName = "Ram", LastName = "Verma", Gender = "Male", Mobile = "9921304656" };

            Appointment a1 = new Appointment { AID = 1, ADate = DateTime.Now.AddDays(1), APatient = p1, ATime = new DateTime(1, 1, 2, 10, 0, 0), AStatus = AppointmentStatus.Pending };
            Appointment a2 = new Appointment { AID = 2, ADate = DateTime.Now.AddDays(1), APatient = p2, ATime = new DateTime(1, 1, 2, 10, 20, 0), AStatus = AppointmentStatus.Pending };
            Appointment a3 = new Appointment { AID = 3, ADate = DateTime.Now.AddDays(1), APatient = p3, ATime = new DateTime(1, 1, 2, 10, 40, 0), AStatus = AppointmentStatus.Pending };
            Appointment a4 = new Appointment { AID = 4, ADate = DateTime.Now.AddDays(1), APatient = p4, ATime = new DateTime(1, 1, 2, 11, 0, 0), AStatus = AppointmentStatus.Pending };
            Appointment a5 = new Appointment { AID = 5, ADate = DateTime.Now.AddDays(1), APatient = p5, ATime = new DateTime(1, 1, 2, 11, 20, 0), AStatus = AppointmentStatus.Pending };
            Appointment a6 = new Appointment { AID = 6, ADate = DateTime.Now.AddDays(1), APatient = p6, ATime = new DateTime(1, 1, 2, 11, 40, 0), AStatus = AppointmentStatus.Pending };
            Appointment a7 = new Appointment { AID = 7, ADate = DateTime.Now.AddDays(1), APatient = p7, ATime = new DateTime(1, 1, 2, 12, 0, 0), AStatus = AppointmentStatus.Pending };
            Appointment a8 = new Appointment { AID = 8, ADate = DateTime.Now.AddDays(1), APatient = p8, ATime = new DateTime(1, 1, 2, 12, 20, 0), AStatus = AppointmentStatus.Pending };
            Appointment a9 = new Appointment { AID = 9, ADate = DateTime.Now.AddDays(1), APatient = p9, ATime = new DateTime(1, 1, 2, 12, 40, 0), AStatus = AppointmentStatus.Pending };
            Appointment a10 = new Appointment { AID = 10, ADate = DateTime.Now.AddDays(1), APatient = p10, ATime = new DateTime(1, 1, 2, 13, 0, 0), AStatus = AppointmentStatus.Pending };
            Appointment a11 = new Appointment { AID = 11, ADate = DateTime.Now.AddDays(1), APatient = p11, ATime = new DateTime(1, 1, 2, 13, 20, 0), AStatus = AppointmentStatus.Pending };
            Appointment a12 = new Appointment { ADate = DateTime.Now.AddDays(1), APatient = p12 };

            patList.AddRange(new List<Patient> { p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11 });
            aptList.AddRange(new List<Appointment> { a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11 });


            var aptData = aptList.AsQueryable();
            var patData = patList.AsQueryable();

            mockset1.As<IQueryable>().Setup(a => a.Provider).Returns(aptData.Provider);
            mockset1.As<IQueryable>().Setup(a => a.Expression).Returns(aptData.Expression);
            mockset1.As<IQueryable>().Setup(a => a.ElementType).Returns(aptData.ElementType);
            mockset1.As<IQueryable>().Setup(a => a.GetEnumerator()).Returns(aptData.GetEnumerator());

            mockset2.As<IQueryable>().Setup(a => a.Provider).Returns(patData.Provider);
            mockset2.As<IQueryable>().Setup(a => a.Expression).Returns(patData.Expression);
            mockset2.As<IQueryable>().Setup(a => a.ElementType).Returns(patData.ElementType);
            mockset2.As<IQueryable>().Setup(a => a.GetEnumerator()).Returns(patData.GetEnumerator());

            mockContext = new Mock<DocApmtContext>();
            mockContext.Setup(a => a.Appointments).Returns(mockset1.Object);
            mockContext.Setup(a => a.Patients).Returns(mockset2.Object);

            mockIManager = new Mock<AppointmentManager>(mockContext.Object);

            var controller = new AppointmentController(mockIManager.Object);

            var result = (RedirectToRouteResult)controller.MakeAppointment_Post(a12);

            Assert.AreEqual("SuccessAppointment", result.RouteValues["action"]);
            Assert.AreEqual(12, result.RouteValues["id"]);
        }

        [Test]
        public void MakeAppointment_Post__Should_Not_Be_MoreThan_12_Test()
        {
            Patient p1 = new Patient { PID = 1, FirstName = "Kush", MiddleName = "Ram", LastName = "Verma", Gender = "Male", Mobile = "9921304656" };
            Patient p2 = new Patient { PID = 2, FirstName = "Ramesh", MiddleName = "Ram", LastName = "Verma", Gender = "Male", Mobile = "9921304656" };
            Patient p3 = new Patient { PID = 3, FirstName = "Somesh", MiddleName = "Ram", LastName = "Verma", Gender = "Male", Mobile = "9921304656" };
            Patient p4 = new Patient { PID = 4, FirstName = "Rajesh", MiddleName = "Ram", LastName = "Verma", Gender = "Male", Mobile = "9921304656" };
            Patient p5 = new Patient { PID = 5, FirstName = "Ajesh", MiddleName = "Ram", LastName = "Verma", Gender = "Male", Mobile = "9921304656" };
            Patient p6 = new Patient { PID = 6, FirstName = "Dinesh", MiddleName = "Ram", LastName = "Verma", Gender = "Male", Mobile = "9921304656" };
            Patient p7 = new Patient { PID = 7, FirstName = "Indrajit", MiddleName = "Ram", LastName = "Verma", Gender = "Male", Mobile = "9921304656" };
            Patient p8 = new Patient { PID = 8, FirstName = "Ramjit", MiddleName = "Ram", LastName = "Verma", Gender = "Male", Mobile = "9921304656" };
            Patient p9 = new Patient { PID = 9, FirstName = "Ajit", MiddleName = "Ram", LastName = "Verma", Gender = "Male", Mobile = "9921304656" };
            Patient p10 = new Patient { PID = 10, FirstName = "Amit", MiddleName = "Ram", LastName = "Verma", Gender = "Male", Mobile = "9921304656" };
            Patient p11 = new Patient { PID = 11, FirstName = "Gaurav", MiddleName = "Ram", LastName = "Verma", Gender = "Male", Mobile = "9921304656" };
            Patient p12 = new Patient { PID = 12, FirstName = "Yuvraj", MiddleName = "Ram", LastName = "Verma", Gender = "Male", Mobile = "9921304656" };
            Patient p13 = new Patient { FirstName = "Samar", MiddleName = "Ram", LastName = "Verma", Gender = "Male", Mobile = "9921304656" };

            Appointment a1 = new Appointment { AID = 1, ADate = DateTime.Now.AddDays(1), APatient = p1, ATime = new DateTime(1, 1, 2, 10, 0, 0), AStatus = AppointmentStatus.Pending };
            Appointment a2 = new Appointment { AID = 2, ADate = DateTime.Now.AddDays(1), APatient = p2, ATime = new DateTime(1, 1, 2, 10, 20, 0), AStatus = AppointmentStatus.Pending };
            Appointment a3 = new Appointment { AID = 3, ADate = DateTime.Now.AddDays(1), APatient = p3, ATime = new DateTime(1, 1, 2, 10, 40, 0), AStatus = AppointmentStatus.Pending };
            Appointment a4 = new Appointment { AID = 4, ADate = DateTime.Now.AddDays(1), APatient = p4, ATime = new DateTime(1, 1, 2, 11, 0, 0), AStatus = AppointmentStatus.Pending };
            Appointment a5 = new Appointment { AID = 5, ADate = DateTime.Now.AddDays(1), APatient = p5, ATime = new DateTime(1, 1, 2, 11, 20, 0), AStatus = AppointmentStatus.Pending };
            Appointment a6 = new Appointment { AID = 6, ADate = DateTime.Now.AddDays(1), APatient = p6, ATime = new DateTime(1, 1, 2, 11, 40, 0), AStatus = AppointmentStatus.Pending };
            Appointment a7 = new Appointment { AID = 7, ADate = DateTime.Now.AddDays(1), APatient = p7, ATime = new DateTime(1, 1, 2, 12, 0, 0), AStatus = AppointmentStatus.Pending };
            Appointment a8 = new Appointment { AID = 8, ADate = DateTime.Now.AddDays(1), APatient = p8, ATime = new DateTime(1, 1, 2, 12, 20, 0), AStatus = AppointmentStatus.Pending };
            Appointment a9 = new Appointment { AID = 9, ADate = DateTime.Now.AddDays(1), APatient = p9, ATime = new DateTime(1, 1, 2, 12, 40, 0), AStatus = AppointmentStatus.Pending };
            Appointment a10 = new Appointment { AID = 10, ADate = DateTime.Now.AddDays(1), APatient = p10, ATime = new DateTime(1, 1, 2, 13, 0, 0), AStatus = AppointmentStatus.Pending };
            Appointment a11 = new Appointment { AID = 11, ADate = DateTime.Now.AddDays(1), APatient = p11, ATime = new DateTime(1, 1, 2, 13, 20, 0), AStatus = AppointmentStatus.Pending };
            Appointment a12 = new Appointment { AID = 12, ADate = DateTime.Now.AddDays(1), APatient = p12, ATime = new DateTime(1, 1, 2, 13, 40, 0), AStatus = AppointmentStatus.Pending };
            Appointment a13 = new Appointment { ADate = DateTime.Now.AddDays(1), APatient = p13 };

            patList.AddRange(new List<Patient> { p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11,p12 });
            aptList.AddRange(new List<Appointment> { a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11,a12 });


            var aptData = aptList.AsQueryable();
            var patData = patList.AsQueryable();

            mockset1.As<IQueryable>().Setup(a => a.Provider).Returns(aptData.Provider);
            mockset1.As<IQueryable>().Setup(a => a.Expression).Returns(aptData.Expression);
            mockset1.As<IQueryable>().Setup(a => a.ElementType).Returns(aptData.ElementType);
            mockset1.As<IEnumerable<Appointment>>().Setup(a => a.GetEnumerator()).Returns(aptData.GetEnumerator());

            mockset2.As<IQueryable>().Setup(a => a.Provider).Returns(patData.Provider);
            mockset2.As<IQueryable>().Setup(a => a.Expression).Returns(patData.Expression);
            mockset2.As<IQueryable>().Setup(a => a.ElementType).Returns(patData.ElementType);
            mockset2.As<IEnumerable<Patient>>().Setup(a => a.GetEnumerator()).Returns(patData.GetEnumerator());

            mockContext = new Mock<DocApmtContext>();
            mockContext.Setup(a => a.Appointments).Returns(mockset1.Object);
            mockContext.Setup(a => a.Patients).Returns(mockset2.Object);

            mockIManager = new Mock<AppointmentManager>(mockContext.Object);

            var controller = new AppointmentController(mockIManager.Object);

            ViewResult result = (ViewResult)controller.MakeAppointment_Post(a13);

            Assert.AreEqual("No Schedule is available", result.ViewData.ModelState.Values.ToArray()[0].Errors[0].ErrorMessage);
        }

        [Test]
        public void SuccessAppointment_Test()
        {
            Patient p1 = new Patient { PID = 1, FirstName = "Kush", MiddleName = "Ram", LastName = "Verma", Gender = "Male", Mobile = "9921304656" };
            Patient p2 = new Patient { PID = 2, FirstName = "Ramesh", MiddleName = "Ram", LastName = "Verma", Gender = "Male", Mobile = "9921304656" };
            Patient p3 = new Patient { PID = 3, FirstName = "Somesh", MiddleName = "Ram", LastName = "Verma", Gender = "Male", Mobile = "9921304656" };
            Patient p4 = new Patient { PID = 4, FirstName = "Rajesh", MiddleName = "Ram", LastName = "Verma", Gender = "Male", Mobile = "9921304656" };
            Patient p5 = new Patient { PID = 5, FirstName = "Ajesh", MiddleName = "Ram", LastName = "Verma", Gender = "Male", Mobile = "9921304656" };
            Patient p6 = new Patient { PID = 6, FirstName = "Dinesh", MiddleName = "Ram", LastName = "Verma", Gender = "Male", Mobile = "9921304656" };
            Patient p7 = new Patient { PID = 7, FirstName = "Indrajit", MiddleName = "Ram", LastName = "Verma", Gender = "Male", Mobile = "9921304656" };
            Patient p8 = new Patient { PID = 8, FirstName = "Ramjit", MiddleName = "Ram", LastName = "Verma", Gender = "Male", Mobile = "9921304656" };
            Patient p9 = new Patient { PID = 9, FirstName = "Ajit", MiddleName = "Ram", LastName = "Verma", Gender = "Male", Mobile = "9921304656" };
            Patient p10 = new Patient { PID = 10, FirstName = "Amit", MiddleName = "Ram", LastName = "Verma", Gender = "Male", Mobile = "9921304656" };
            Patient p11 = new Patient { PID = 11, FirstName = "Gaurav", MiddleName = "Ram", LastName = "Verma", Gender = "Male", Mobile = "9921304656" };
            Patient p12 = new Patient { PID = 12, FirstName = "Yuvraj", MiddleName = "Ram", LastName = "Verma", Gender = "Male", Mobile = "9921304656" };

            Appointment a1 = new Appointment { AID = 1, ADate = DateTime.Now.AddDays(1), APatient = p1, ATime = new DateTime(1, 1, 2, 10, 0, 0), AStatus = AppointmentStatus.Pending };
            Appointment a2 = new Appointment { AID = 2, ADate = DateTime.Now.AddDays(1), APatient = p2, ATime = new DateTime(1, 1, 2, 10, 20, 0), AStatus = AppointmentStatus.Pending };
            Appointment a3 = new Appointment { AID = 3, ADate = DateTime.Now.AddDays(1), APatient = p3, ATime = new DateTime(1, 1, 2, 10, 40, 0), AStatus = AppointmentStatus.Pending };
            Appointment a4 = new Appointment { AID = 4, ADate = DateTime.Now.AddDays(1), APatient = p4, ATime = new DateTime(1, 1, 2, 11, 0, 0), AStatus = AppointmentStatus.Pending };
            Appointment a5 = new Appointment { AID = 5, ADate = DateTime.Now.AddDays(1), APatient = p5, ATime = new DateTime(1, 1, 2, 11, 20, 0), AStatus = AppointmentStatus.Pending };
            Appointment a6 = new Appointment { AID = 6, ADate = DateTime.Now.AddDays(1), APatient = p6, ATime = new DateTime(1, 1, 2, 11, 40, 0), AStatus = AppointmentStatus.Pending };
            Appointment a7 = new Appointment { AID = 7, ADate = DateTime.Now.AddDays(1), APatient = p7, ATime = new DateTime(1, 1, 2, 12, 0, 0), AStatus = AppointmentStatus.Pending };
            Appointment a8 = new Appointment { AID = 8, ADate = DateTime.Now.AddDays(1), APatient = p8, ATime = new DateTime(1, 1, 2, 12, 20, 0), AStatus = AppointmentStatus.Pending };
            Appointment a9 = new Appointment { AID = 9, ADate = DateTime.Now.AddDays(1), APatient = p9, ATime = new DateTime(1, 1, 2, 12, 40, 0), AStatus = AppointmentStatus.Pending };
            Appointment a10 = new Appointment { AID = 10, ADate = DateTime.Now.AddDays(1), APatient = p10, ATime = new DateTime(1, 1, 2, 13, 0, 0), AStatus = AppointmentStatus.Pending };
            Appointment a11 = new Appointment { AID = 11, ADate = DateTime.Now.AddDays(1), APatient = p11, ATime = new DateTime(1, 1, 2, 13, 20, 0), AStatus = AppointmentStatus.Pending };
            Appointment a12 = new Appointment { AID = 12, ADate = DateTime.Now.AddDays(1), APatient = p12, ATime = new DateTime(1, 1, 2, 13, 40, 0), AStatus = AppointmentStatus.Pending };

            patList.AddRange(new List<Patient> { p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12 });
            aptList.AddRange(new List<Appointment> { a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11, a12 });

            var aptData = aptList.AsQueryable();
            var patData = patList.AsQueryable();

            mockset1.As<IQueryable>().Setup(a => a.Provider).Returns(aptData.Provider);
            mockset1.As<IQueryable>().Setup(a => a.Expression).Returns(aptData.Expression);
            mockset1.As<IQueryable>().Setup(a => a.ElementType).Returns(aptData.ElementType);
            mockset1.As<IEnumerable<Appointment>>().Setup(a => a.GetEnumerator()).Returns(aptData.GetEnumerator());

            mockset2.As<IQueryable>().Setup(a => a.Provider).Returns(patData.Provider);
            mockset2.As<IQueryable>().Setup(a => a.Expression).Returns(patData.Expression);
            mockset2.As<IQueryable>().Setup(a => a.ElementType).Returns(patData.ElementType);
            mockset2.As<IEnumerable<Patient>>().Setup(a => a.GetEnumerator()).Returns(patData.GetEnumerator());

            mockset1.Setup(a => a.Include(It.IsAny<string>())).Returns(mockset1.Object);

            mockContext = new Mock<DocApmtContext>();
            mockContext.Setup(a => a.Appointments).Returns(mockset1.Object);
            mockContext.Setup(a => a.Patients).Returns(mockset2.Object);

            mockIManager = new Mock<AppointmentManager>(mockContext.Object);

            var controller = new AppointmentController(mockIManager.Object);

            var result = controller.SuccessAppointment(1) as ViewResult;

            Assert.AreEqual(a1,result.Model);
        }
    }
}
