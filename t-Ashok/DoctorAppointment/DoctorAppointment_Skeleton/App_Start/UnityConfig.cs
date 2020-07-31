using DoctorAppointment_Skeleton.Models;
using DoctorAppointment_Skeleton.Models.Context;
using System.Web.Mvc;
using Unity;
using Unity.Injection;
using Unity.Mvc5;

namespace DoctorAppointment_Skeleton
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<IAppointmentManager, AppointmentManager>(new InjectionConstructor(new DocApmtContext()));

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}