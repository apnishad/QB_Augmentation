using DoctorAppointment.Controllers;
using DoctorAppointment.Models;
using DoctorAppointment.Models.Context;
using System.Web.Mvc;
using Unity;
using Unity.Injection;
using Unity.Mvc5;

namespace DoctorAppointment
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
                        
            container.RegisterType<IAppointmentManager, AppointmentManager>(new InjectionConstructor(new DocApmtContext()));
            

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}